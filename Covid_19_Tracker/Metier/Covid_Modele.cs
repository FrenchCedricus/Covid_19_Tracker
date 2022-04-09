using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid_19_Tracker
{
    class Covid_Modele
    {
        public string date { get; set; }
        public object tx_pos { get; set; }
        public object tx_incid { get; set; }
        public double TO { get; set; }
        public object R { get; set; }
        public int rea { get; set; }
        public int hosp { get; set; }
        public int rad { get; set; }
        public int dchosp { get; set; }
        public int incid_rea { get; set; }
        public int incid_hosp { get; set; }
        public int incid_rad { get; set; }
        public int incid_dchosp { get; set; }
        public object conf { get; set; }
        public int conf_j1 { get; set; }
        public object pos { get; set; }
        public int esms_dc { get; set; }
        public int dc_tot { get; set; }
        public object pos_7j { get; set; }
        public object cv_dose1 { get; set; }
        public int esms_cas { get; set; }

    }
}
