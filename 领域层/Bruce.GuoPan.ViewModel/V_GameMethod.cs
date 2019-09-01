using NLite.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bruce.GuoPan.ViewModel
{
    [Table("V_GameMethod")]
    public class V_GameMethod
    {
        /// <summary>
        ///   
        /// </summary>
        public int MethodId { get; set; }
        /// <summary>
        ///   
        /// </summary>
        public string MethodName { get; set; }

        /// <summary>
        ///   
        /// </summary>
        public int TicketId { get; set; }
        /// <summary>
        ///   
        /// </summary>
        public string TicketName { get; set; }


        /// <summary>
        ///   
        /// </summary>
        public int GroupId { get; set; }
        /// <summary>
        ///   
        /// </summary>
        public string GroupName { get; set; }


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
