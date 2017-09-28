using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace PaquetWorld
{
    class ADO
    {
        public SqlConnection con = new SqlConnection();
        public SqlCommand cmd = new SqlCommand();
        public void Connecter()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = "data source = etudiants.cegepsth.qc.ca; initial catalog = GED-Equipe1-2017; user id = Equipe1; password = maison; MultipleActiveResultSets = True; App = EntityFramework";
                con.Open();
            }

           
            
        }
        public void Deconnecter()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
