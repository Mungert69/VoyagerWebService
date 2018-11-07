using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;

using System.Collections.Generic;
using System.IO;


/// <summary>
/// Summary description for MapButtons
/// </summary>
public class MapService : IMapService
{


    private  IPlaceAdapter _placeAdapter;
    private ITransferAdapter _transferAdapter;
    public MapService( IPlaceAdapter placeAdapter, ITransferAdapter transferAdapter)
    {

        _placeAdapter = placeAdapter;
        _transferAdapter = transferAdapter;
    }
    public static void get(SessionObject sessionObj, EventHandler MapButton_Click)
    {
        /*
        PlaceAdapter placeAdapter = new PlaceAdapter();
        //PlaceHolder placeHolder = (PlaceHolder)sessionObj.Page.FindControl("MapBtnPlaceHolder");
        //placeHolder.Controls.Clear();
        foreach (PlaceObj placeObj in placeAdapter.getPlaces(false))
        {
            if (placeObj.MapOrder != 0)
            {
                string temp = placeObj.PlaceName;
                temp = temp.Replace(" ", "_");

                HtmlObject htmlObj = new HtmlObject();
                htmlObj.htmlStr = " ";
                HyperLink mapBtn = new HyperLink();
                mapBtn.ID = temp;
                mapBtn.Text = placeObj.ShortPlaceName;
                if (sessionObj.PageStates.NavigateUrlOn) mapBtn.NavigateUrl = "builder.aspx?place=" + placeObj.PlaceName + "&hotel=&mapclick=yes";
                if (sessionObj.PageStates.AltHoverOn)
                {
                    mapBtn.Attributes["onmouseover"] = placeAdapter.getOnMouseAlt();

                }
                else
                {
                    mapBtn.Attributes["onmouseover"] = placeAdapter.getOnMouse(placeObj.PlaceID, placeObj.PlaceName);
                }

                placeHolder.Controls.Add(mapBtn);
                //placeHolder.Controls.Add(VoyUtils.insertSpaces(1));
                placeHolder.Controls.Add(htmlObj);

                if (mapBtn != null)
                {


                    if (sessionObj.PlaceStates.getIsHop(placeObj.PlaceID))
                    {
                        mapBtn.CssClass = "mapBtnHop";

                    }
                    else
                    {
                        mapBtn.CssClass = "mapBtn";
                    }
                    if (sessionObj.PRSelections != null)
                    {
                        foreach (PRSelection selection in sessionObj.PRSelections)
                        {
                            if (selection.PlaceID == placeObj.PlaceID)
                            {
                                mapBtn.CssClass = "mapBtnSelected";
                            }

                        }
                    }
                    // mapBtn.Click += MapButton_Click;
                    //mapBtn.CommandArgument = Convert.ToString(placeObj.PlaceID);

                }
            }
        }
        */
    }

    public  List<PlaceState> selectHops(ISessionObject sessionObj)
    {
        // PlaceAdapter placeAdapter = new PlaceAdapter();
        //TransferAdapter transferAdapter = new TransferAdapter();
        List<PlaceObj> placeObjs = _placeAdapter.getPlaces(false);

        if (sessionObj.PlaceStates == null) {
            sessionObj.PlaceStates = new PlaceStates(placeObjs);
        }
        
        foreach (PlaceObj placeObj in placeObjs)
        {
            sessionObj.PlaceStates.setIsHop(placeObj.PlaceID, false);
            foreach (PRSelection selection in sessionObj.PRSelections) {
                if (selection.PlaceID == placeObj.PlaceID) {
                    sessionObj.PlaceStates.setIsSelected(placeObj.PlaceID, true);
                }
            }
        }

        // Dont set any place states if in template mode.
        if (!(sessionObj.PageStates.IsTemplate  ))
        {
            if (!sessionObj.PageStates.FirstPlaceSelected)
            {
                foreach (int hop in _transferAdapter.getNextAirportHops(sessionObj.Flight.ArriveAirportID, sessionObj.WithCar))
                {
                    sessionObj.PlaceStates.setIsHop(hop, true);
                }

            }
            else
            {
                foreach (int hop in _transferAdapter.getNextHops(sessionObj.PrevPlaceID, sessionObj.WithCar))
                {
                    sessionObj.PlaceStates.setIsHop(hop, true);
                }

            }
        }

        return sessionObj.PlaceStates.States;

    }

}
