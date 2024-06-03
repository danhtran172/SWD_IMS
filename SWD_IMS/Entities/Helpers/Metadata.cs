﻿namespace SWD_IMS.Entities.Helpers
{
    public class Metadata
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }
        public int PageSize { get; set; }

        // Return true if the current page is greater than 1, otherwise false
        public bool hasPreviousPage => CurrentPage > 1;
        // Return true if the current page is less than the total pages, otherwise false
        public bool hasNextPage => CurrentPage < TotalPages;
    }
}
