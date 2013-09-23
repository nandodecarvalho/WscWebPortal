using System;
using System.Data;
using System.Data.Common;

/// <summary>
/// Wraps product information data.we could put this code on the StoreAccess but let's keep things organized.
/// </summary>
public struct ProductInfo
{
    public int ProductID;
    public string ProductName;
    public string ProductDescription;
    public decimal ProductPrice;
    public string ProductThumb;
    public string ProductImage;
    public bool BestSellShop;
    public bool BestSellCategory;
}