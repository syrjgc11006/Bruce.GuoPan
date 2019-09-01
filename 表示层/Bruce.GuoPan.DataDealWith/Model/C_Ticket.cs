using NLite.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bruce.GuoPan.DataDealWith.Model
{
    [Table("C_Ticket")]
    public class C_Ticket
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
        public int CurrentCloseState { get; set; }
        /// <summary>
        ///   
        /// </summary>
        public string CurrentCase { get; set; }
        /// <summary>
        ///   
        /// </summary>
        public DateTime? CurrentCaseOpenTime { get; set; }
        /// <summary>
        ///   
        /// </summary>
        public DateTime? CurrentCaseCloseTime { get; set; }
        /// <summary>
        ///   
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        ///   
        /// </summary>
        public int Order { get; set; }
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
        public int Type { get; set; }
        /// <summary>
        ///   
        /// </summary>
        public DateTime? OpenDateTime { get; set; }
        /// <summary>
        ///   
        /// </summary>
        public string OutCode { get; set; }
        /// <summary>
        ///   
        /// </summary>
        public string ImgUrl { get; set; }
        /// <summary>
        ///   
        /// </summary>
        public string Memo1 { get; set; }
        /// <summary>
        ///   
        /// </summary>
        public string Memo2 { get; set; }
    }
}