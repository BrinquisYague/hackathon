using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using System.IO;
using System.Text.Json;

[System.Serializable]
public class Planeta_json
    {
        public double kepid;
        public string kepoi_name;
        public string kepler_name;
        public string koi_disposition;
        public string koi_pdisposition;
        public double koi_score;
        public double koi_fpflag_nt;
        public double koi_fpflag_ss;
        public double koi_fpflag_co;
        public double koi_fpflag_ec;
        public double koi_period;
        public double koi_period_err1;
        public double koi_period_err2;
        public double koi_time0bk;
        public double intkoi_time0bk_err1;
        public double koi_time0bk_err2;
        public double koi_impact;
        public double koi_impact_err1;
        public double koi_impact_err2;
        public double koi_duration;
        public double koi_duration_err1;
        public double koi_duration_err2;
        public double koi_depth;
        public double koi_depth_err1;
        public double koi_depth_err2;
        public double koi_prad;
        public double koi_prad_err1;
        public double koi_prad_err2;
        public double koi_teq;
        public string koi_teq_err1;
        public string koi_teq_err2;
        public double koi_insol;
        public double koi_insol_err1;
        public double koi_insol_err2;
        public double koi_model_snr;
        public double koi_tce_plnt_num;
        public string koi_tce_delivname;
        public double koi_steff;
        public double koi_steff_err1;
        public double koi_steff_err2;
        public double koi_slogg;
        public double koi_slogg_err1;
        public double koi_slogg_err2;
        public double koi_srad;
        public double koi_srad_err1;
        public double koi_srad_err2;
        public string ra_str;
        public string dec_str;
        public double koi_kepmag;
        public string koi_kepmag_err;


    };

    public class API_CONECTOR_MANAGER : MonoBehaviour
    {
        public Planeta_json ultimo_planeta;
        public List<Planeta_json> planetas_leidos;
        private const string BASE_URL = "https://exoplanetarchive.ipac.caltech.edu/cgi-bin/nstedAPI/nph-nstedAPI?table=";
        private const string WHERE = "&where=";
        private const string LIKE = " like '";
        private const string AND = "' and ";
        private const string FORMAT_URL = "'&format=";
        public List<string> labelTable;
        public List<string> valueTable;
        public string tableName;
        public string format;
        private string webUrl;
        private WebRequest wrGETURL;


        // Start is called before the first frame update
        void Start()
        {
            webAPIData();
            getWebAPIData();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void webAPIData()
        {
            createURLRequest();
            wrGETURL = WebRequest.Create(webUrl);
        }

        private void getWebAPIData()
        {
            Stream objStream;
            objStream = wrGETURL.GetResponse().GetResponseStream();
            StreamReader objReader = new StreamReader(objStream);
            string jsonString = objReader.ReadToEnd();
            jsonString = jsonString.Replace("[", "");
            jsonString = jsonString.Replace("]", "");
            Debug.Log(jsonString);

            // Deserializar el JSON en un objeto Planeta_json
            ultimo_planeta = JsonUtility.FromJson<Planeta_json>(jsonString);

            // Agrega el último planeta a la lista de planetas_leidos
            if (planetas_leidos == null)
            {
                planetas_leidos = new List<Planeta_json>();
            }

            planetas_leidos.Add(ultimo_planeta);
        }


        private void createURLRequest()
        {
            webUrl = BASE_URL + tableName + WHERE;
            if (valueTable.Count <= 1 && valueTable.Count > 0)
                webUrl += labelTable[0] + LIKE + valueTable[0] + FORMAT_URL + format;
            else if (valueTable.Count > 0)
            {
                for (int i = 0; i < valueTable.Count; i++)
                {
                    if (i < valueTable.Count - 1)
                        webUrl += labelTable[i] + LIKE + valueTable[i] + AND;
                    else
                        webUrl += labelTable[i] + LIKE + valueTable[i] + FORMAT_URL + format;

                }
            }

            Debug.Log(webUrl);

        }
    }

