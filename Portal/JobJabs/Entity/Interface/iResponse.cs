// -----------------------------------------------------------------------
// <copyright file="iResponse.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace JobJabs.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public interface iResponse
    {
         int Status { get; set; }
         string Message { get; set; }
         dynamic Data { get; set; }
    }

    public class ApiResponse : iResponse
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }
    }
}
