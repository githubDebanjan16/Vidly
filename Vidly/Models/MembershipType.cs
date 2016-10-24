using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public short SighUpFee { get; set; }
        public byte DurationInMonth { get; set; }
        public byte DiscoutRate { get; set; }
        public string MembershipName { get; set; }

        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;

    }
}