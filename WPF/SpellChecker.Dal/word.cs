//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SpellChecker.Dal
{
    using System;
    using System.Collections.Generic;
    
    public partial class word
    {
        public string word_id { get; set; }
        public string phonetic_value { get; set; }
        public int word_status_id { get; set; }
        public Nullable<System.DateTime> edit_date_time { get; set; }
        public Nullable<int> edit_user_id { get; set; }
        public Nullable<System.DateTime> server_sync_time { get; set; }
        public Nullable<System.DateTime> local_sync_time { get; set; }
        public System.Guid word_guid { get; set; }
        public string import_link { get; set; }
    }
}
