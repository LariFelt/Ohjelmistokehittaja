﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20_CRUD
{
    internal class OPISKELIJA
    {
        Yhdista yhteys = new Yhdista();
    

    public bool lisaaOpiskelija(String enimi, String snimi, String puh, String email, int onro)
    {
        MySqlCommand komento = new MySqlCommand();
        String lisayskysely = "INSERT INTO yhteystiedott " +
                "(etunimi, sukunimi, puhelin, sahkoposti, opiskelijanumero) " +
            "VALUES (@enm, @snm, @puh, @eml, @ono); ";
        komento.CommandText = lisayskysely;
        komento.Connection = yhteys.otaYhteys();
        komento.Parameters.Add("@enm", MySqlDbType.VarChar).Value = enimi;
        komento.Parameters.Add("@snm", MySqlDbType.VarChar).Value = snimi;
        komento.Parameters.Add("@puh", MySqlDbType.VarChar).Value = puh;
        komento.Parameters.Add("@eml", MySqlDbType.VarChar).Value = email;
        komento.Parameters.Add("@ono", MySqlDbType.UInt32).Value = onro;

        yhteys.avaaYhteys();
        if (komento.ExecuteNonQuery() == 1)
        {
            yhteys.suljeYhteys();
            return true;
        }
        else
        {
            yhteys.suljeYhteys();
            return false;
        }
    }
        public DataTable haeOpiskelijat()
        {
            MySqlCommand komento = new MySqlCommand("SELECT oid, etunimi, sukunimi, puhelin, sahkoposti, opiskelijanumero FROM yhteystiedott", yhteys.otaYhteys());
            MySqlDataAdapter adapteri = new MySqlDataAdapter();
            DataTable taulu = new DataTable();

            adapteri.SelectCommand = komento;
            adapteri.Fill(taulu);

            return taulu;
        }

        public bool muokkaaOpiskelijaa(int oid, String enimi, String snimi, String puh, String email, int onro)
        {
            MySqlCommand komento = new MySqlCommand();
            String paivityskysely = "UPDATE `yhteystiedott` SET `Etunimi`=@enm, `Sukunimi`=@snm, `puhelin`=@puh, `sahkoposti`=@eml, `opiskelijanumero`=@ono WHERE `oid` = @oid";
            komento.CommandText = paivityskysely;
            komento.Connection = yhteys.otaYhteys();
            komento.Parameters.Add("@enm", MySqlDbType.VarChar).Value = enimi;
            komento.Parameters.Add("@snm", MySqlDbType.VarChar).Value = snimi;
            komento.Parameters.Add("@puh", MySqlDbType.VarChar).Value = puh;
            komento.Parameters.Add("@eml", MySqlDbType.VarChar).Value = email;
            komento.Parameters.Add("@ono", MySqlDbType.UInt32).Value = onro;
            komento.Parameters.Add("@oid", MySqlDbType.UInt32).Value = oid;

            yhteys.avaaYhteys();
            if (komento.ExecuteNonQuery() == 1)
            {
                yhteys.suljeYhteys();
                return true;
            }
            else 
            {
                yhteys.suljeYhteys();
               return false; 
            }
        }

        public bool poistaOpiskelija(String ktunnus)
        {
            MySqlCommand komento = new MySqlCommand();
            String poistokysely = "DELETE FROM yhteystiedott WHERE oid = @ktu";
            komento.CommandText = poistokysely;
            komento.Connection = yhteys.otaYhteys();
            komento.Parameters.Add("@ktu", MySqlDbType.UInt32).Value = ktunnus;

            yhteys.avaaYhteys();
            if (komento.ExecuteNonQuery()==1) 
            {
                yhteys.suljeYhteys();
                return true;    
            }
            else
            {
                yhteys.suljeYhteys();
                return false;
            }
        }
        
    }
}
