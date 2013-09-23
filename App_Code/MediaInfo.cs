using System;
using System.Data;
using System.Data.Common;

//// <summary>
/// Wraps media details data. we could put this code on the StoreAccess but let's keep things organized.

/// </summary>
public struct MediaInfo
{
    public int ShopMenuId;
    public string MediaName;
    public string MediaDescription;
}