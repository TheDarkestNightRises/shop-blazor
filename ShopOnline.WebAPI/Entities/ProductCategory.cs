﻿namespace ShopOnline.WebAPI.Entities
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IconCSS { get; internal set; }
    }
}
