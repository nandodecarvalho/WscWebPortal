using System;
using System.Data;
using System.Data.Common;


/// <summary>
/// Wraps shopmenu information data. we could put this code on the StoreAccess but let's keep things organized.
/// </summary>
public struct ShopMenuInfo
{
    public string ShopMenuName;
    public string ShopMenuDescription;
}