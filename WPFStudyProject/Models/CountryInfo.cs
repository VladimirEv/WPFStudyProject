using System.Collections.Generic;

namespace WPFStudyProject.Models
{
    internal class CountryInfo : PlaceInfo 
    { 
        public IEnumerable<ProvinceInfo>? ProvinceCounts { get; set; }
    }
}
