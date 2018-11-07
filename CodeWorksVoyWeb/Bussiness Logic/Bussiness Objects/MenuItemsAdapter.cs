using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


/// <summary>
/// Summary description for MenuItemsAdapter
/// </summary>
public class MenuItemsAdapter
{
    public List<MenuObj> getMenuObjs() {
        List<MenuObj> menuObjs = new List<MenuObj>();
        /*
        CubaMenuMASTER1TableAdapter adapt = new CubaMenuMASTER1TableAdapter();
        MenuData.CubaMenuMASTER1DataTable table = adapt.GetData();
        foreach (MenuData.CubaMenuMASTER1Row row in table) {
            MenuObj menuObj = new MenuObj();
            menuObj.FileType = row.FileType;
            menuObj.InfoPageName = row.INFOPageName;
            menuObj.MapGroupType = row.MapGroupType;
            menuObj.MenuLevel1 = row.MenuLevel1;
            menuObj.MenuLevel2 = row.MenuLevel2;
            menuObj.MenuLevel3 = row.MenuLevel3;
            menuObj.MenuLevel4 = row.MenuLevel4;
            menuObj.PictureGroupType = row.PictureGroupType;
            menuObj.Seo1 = row.SEO1;
            menuObj.Seo2 = row.SEO2;
            menuObj.Visible = row.VisableOnMenu;
            menuObj.Priority = row.Priority;
            menuObj.UseIt = row.use_it;
            menuObj.IndexPath = row.IndexPath;
            

            menuObjs.Add(menuObj);
        }*/
        return menuObjs;
    
    }

    public void truncateTables() {
        /*
        TruncateTableAdapter adapt = new TruncateTableAdapter();
        adapt.TruncateMenuTables();
        */
    }

    public PageParam getPathLevelChild(string currentLevel) {
        PageParam pageParam = new PageParam();
        /*
        PageParametersTableAdapter adapt = new PageParametersTableAdapter();
        MenuItems.PageParametersDataTable table = adapt.GetChildPageByPathLevel(currentLevel);
        foreach (MenuItems.PageParametersRow row in table)
        {
            pageParam.FileType = row.FileType;
            pageParam.InfoPageName = row.InfoPageName;
            pageParam.MapGroupType = row.MapGroupType;
            pageParam.PictureGroupType = row.PictureGroupType;
            pageParam.Seo1 = row.SEO1;
            pageParam.Seo2 = row.SEO2;
            pageParam.Path = row.Path;
            pageParam.Visible = row.Visible;
            pageParam.IndexPath = row.IndexPath;
            break;
        }
        */
        return pageParam;
    }



    public PageParam getPageParams(string currentLevel) {
        PageParam pageParam = new PageParam();
        /*
        PageParametersTableAdapter adapt = new PageParametersTableAdapter();
        MenuItems.PageParametersDataTable table = adapt.GetDataByPathLevel(currentLevel);
        foreach (MenuItems.PageParametersRow row in table) {
            pageParam.FileType = row.FileType;
            pageParam.InfoPageName = row.InfoPageName;
            pageParam.MapGroupType = row.MapGroupType;
            pageParam.PictureGroupType = row.PictureGroupType;
            pageParam.Seo1 = row.SEO1;
            pageParam.Seo2 = row.SEO2;
            pageParam.Path = row.Path;
            pageParam.Visible = row.Visible;
            pageParam.IndexPath = row.IndexPath;
        }*/
        return pageParam;
    }

    public string convert2PathLevel(string currentLevel)
    {
        PageParam pageParam = new PageParam();
        /*
        PageParametersTableAdapter adapt = new PageParametersTableAdapter();
        MenuItems.PageParametersDataTable table = adapt.GetPathLevelByURL(currentLevel);
        foreach (MenuItems.PageParametersRow row in table)
        {
            return row.PathLevel;
        }*/
        return "";
    }


    public void updatePageParameters(List<PageParam> pageParams) {
        /*
        PageParametersTableAdapter adapt = new PageParametersTableAdapter();
        foreach( PageParam row in pageParams)
        {
            adapt.Insert(row.PathLevel, row.MapGroupType, row.PictureGroupType, row.Seo1, row.Seo2, row.UseIt, row.FileType, row.InfoPageName, row.Path, row.Visible, row.IndexPath, row.Priority);
        }
        */
    }

   

    public void updateMenuLeve1(List<int> menuLevel1ID, List<string> name, List<string> path , List<string> menuLevel, List<bool> visible, List<int> priority) {
        /*
        MenuLevel1TableAdapter adapt = new MenuLevel1TableAdapter();
        for (int i = 0; i < menuLevel1ID.Count; i++)
        {
            adapt.Insert(menuLevel1ID[i], name[i], path[i], menuLevel[i], visible[i], priority[i]);
        }*/
    
    }

    public void updateMenuLeve2(List<int> menuLevel2ID, List<int> menuLevel2x1ID, List<string> name, List<string> path, List<string> menuLevel, List<bool> visible, List<int> priority)
    {
        /*
        MenuLevel2TableAdapter adapt = new MenuLevel2TableAdapter();
        for (int i = 0; i < menuLevel2ID.Count; i++)
        {
            adapt.Insert(menuLevel2x1ID[i], menuLevel2ID[i], name[i], path[i], menuLevel[i], visible[i], priority[i]);
        }
        */
    }
    public void updateMenuLeve3(List<int> menuLevel3ID, List<int> menuLevel3x1ID, List<int> menuLevel3x2ID, List<string> name, List<string> path, List<string> menuLevel, List<bool> visible, List<int> priority)
    {
        /*
        MenuLevel3TableAdapter adapt = new MenuLevel3TableAdapter();
        for (int i = 0; i < menuLevel3ID.Count; i++)
        {
            adapt.Insert(menuLevel3x1ID[i], menuLevel3x2ID[i], menuLevel3ID[i], name[i], path[i], menuLevel[i], visible[i], priority[i]);
        }*/

    }
    public void updateMenuLeve4(List<int> menuLevel4ID, List<int> menuLevel4x1ID, List<int> menuLevel4x2ID, List<int> menuLevel4x3ID, List<string> name, List<string> path, List<string> menuLevel, List<bool> visible, List<int> priority)
    {/*
        MenuLevel4TableAdapter adapt = new MenuLevel4TableAdapter();
        for (int i = 0; i < menuLevel4ID.Count; i++)
        {
            adapt.Insert(menuLevel4x1ID[i], menuLevel4x2ID[i], menuLevel4x3ID[i], menuLevel4ID[i], name[i], path[i], menuLevel[i], visible[i], priority[i]);
        }*/

    }

    public List<MenuLevelItem> getLevel1Items() {
        List<MenuLevelItem> menuItems = new List<MenuLevelItem>();
        /*
        MenuLevel1TableAdapter adapt = new MenuLevel1TableAdapter();
        MenuItems.MenuLevel1DataTable table = adapt.GetData();

        foreach (MenuItems.MenuLevel1Row row in table)
        {
            MenuLevelItem menuItem=new MenuLevelItem();
            menuItem.Level=Convert.ToString(row.ID1)+"x-1x-1x-1";
            menuItem.Name=row.Name;
            menuItem.Path=row.Path;
            menuItem.Visible=row.Visible;
            menuItems.Add(menuItem);
        }
        return menuItems;
    }
    public List<MenuLevelItem> getLevel2Items(string currentLevel)
    {
        string[] levels = currentLevel.Split('x');
        if (levels.Length > 0)
        {
            List<MenuLevelItem> menuItems = new List<MenuLevelItem>();
            MenuLevel2TableAdapter adapt = new MenuLevel2TableAdapter();
            MenuItems.MenuLevel2DataTable table = adapt.GetDataByLevel1ID(Convert.ToInt32(levels[0]));

            foreach (MenuItems.MenuLevel2Row row in table)
            {
                MenuLevelItem menuItem=new MenuLevelItem();
                 menuItem.Level=Convert.ToString(row.ID1) + "x" + Convert.ToString(row.ID2)+"x-1x-1";
            menuItem.Name=row.Name;
            menuItem.Path=row.Path;
            menuItem.Visible=row.Visible;
            menuItems.Add(menuItem);
 
            }
            return menuItems;
        }
        else*/ 
        return null;
    }
    public List<MenuLevelItem> getLevel3Items(string currentLevel)
    {
        /*
        string[] levels = currentLevel.Split('x');
        if (levels.Length > 1)
        {
            List<MenuLevelItem> menuItems = new List<MenuLevelItem>();
            MenuLevel3TableAdapter adapt = new MenuLevel3TableAdapter();
            MenuItems.MenuLevel3DataTable table = adapt.GetDataByLevel2ID(Convert.ToInt32(levels[1]), Convert.ToInt32(levels[0]));

            foreach (MenuItems.MenuLevel3Row row in table)
            {
                 MenuLevelItem menuItem=new MenuLevelItem();
                 menuItem.Level=Convert.ToString(row.ID1) + "x" + Convert.ToString(row.ID2) + "x" + Convert.ToString(row.ID3)+"x-1";
            menuItem.Name=row.Name;
            menuItem.Path=row.Path;
            menuItem.Visible=row.Visible;
            menuItems.Add(menuItem);
               }
            return menuItems;
        }
        
        else { */
                return null; 
    }
    public List<MenuLevelItem> getLevel4Items(string currentLevel)
    {
        /*
        string[] levels = currentLevel.Split('x');
        if (levels.Length > 2)
        {
            List<MenuLevelItem> menuItems = new List<MenuLevelItem>();
            MenuLevel4TableAdapter adapt = new MenuLevel4TableAdapter();
            MenuItems.MenuLevel4DataTable table = adapt.GetDataByLevel3ID(Convert.ToInt32(levels[2]), Convert.ToInt32(levels[1]), Convert.ToInt32(levels[0]));

            foreach (MenuItems.MenuLevel4Row row in table)
            {
                MenuLevelItem menuItem=new MenuLevelItem();
                 menuItem.Level=Convert.ToString(row.ID1) + "x" + Convert.ToString(row.ID2) + "x" + Convert.ToString(row.ID3) + "x" + Convert.ToString(row.ID4);
            menuItem.Name=row.Name;
            menuItem.Path=row.Path;
            menuItem.Visible=row.Visible;
            menuItems.Add(menuItem);
                 }
            return menuItems;
        }
        else {*/
        return null; 
    }
}
