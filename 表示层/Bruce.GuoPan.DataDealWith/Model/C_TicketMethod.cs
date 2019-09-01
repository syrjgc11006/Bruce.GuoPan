﻿using NLite.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bruce.GuoPan.DataDealWith.Model
{
    [Table("C_TicketMethod")]
    public class C_TicketMethod 
    {
        /// <summary>
        ///   
        /// </summary>
        [Id(IsDbGenerated =false)]
        public int ID { get; set; }
        /// <summary>
        ///   
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        ///   
        /// </summary>
        public int MethodGroupID { get; set; }
        /// <summary>
        ///   
        /// </summary>
        public int Order { get; set; }
        /// <summary>
        ///   
        /// </summary>
        public int? GroupNum { get; set; }
        /// <summary>
        ///   
        /// </summary>
        public int AddUser { get; set; }
        /// <summary>
        ///   
        /// </summary>
        public DateTime AddTime { get; set; }
        /// <summary>
        ///   
        /// </summary>
        public int LastModifyUser { get; set; }
        /// <summary>
        ///   
        /// </summary>
        public DateTime LastModifyTime { get; set; }
        /// <summary>
        ///   
        /// </summary>
        public int Enable { get; set; }
        /// <summary>
        ///   
        /// </summary>
        public string Memo { get; set; }
        /// <summary>
        ///   
        /// </summary>
        public string OutCode { get; set; }
    }
}