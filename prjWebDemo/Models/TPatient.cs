using System;
using System.Collections.Generic;

namespace prjWebDemo.Models
{
    public partial class TPatient
    {
        public int FId { get; set; }
        public string? FName { get; set; }
        public string? FPhone { get; set; }
        public string? FEmail { get; set; }
        public string? FAddress { get; set; }
        public string? FPassword { get; set; }
        public string? F健保卡號 { get; set; }
        public string? F身分證號 { get; set; }
        public byte[]? FPicture { get; set; }
    }
}
