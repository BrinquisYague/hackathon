using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using System.IO;
using System.Text.Json.Serialization;


public struct Planeta_json
    {
        int kepid;
        string kepoi_name;
        string kepler_name;
        string koi_disposition;
        string koi_pdisposition;
        double koi_score;
        double koi_fpflag_nt;
        double koi_fpflag_ss;
        double koi_fpflag_co;
        double koi_fpflag_ec;
        double koi_period;
        double koi_period_err1;
        double koi_period_err2;
        double koi_time0bk;
        double intkoi_time0bk_err1;
        double koi_time0bk_err2;
        double koi_impact;
        double koi_impact_err1;
        double koi_impact_err2;
        double koi_duration;
        double koi_duration_err1;
        double koi_duration_err2;
        double koi_depth;
        double koi_depth_err1;
        double koi_depth_err2;
        double koi_prad;
        double koi_prad_err1;
        double koi_prad_err2;
        double koi_teq;
        double koi_teq_err1;
        double koi_teq_err2;
        double koi_insol;
        double koi_insol_err1;
        double koi_insol_err2;
        double koi_model_snr;
        double koi_tce_plnt_num;
        double koi_tce_delivname;
        double koi_steff;
        double koi_steff_err1;
        double koi_steff_err2;
        double koi_slogg;
        double koi_slogg_err1;
        double koi_slogg_err2;
        double koi_srad;
        double koi_srad_err1;
        double koi_srad_err2;
        string ra_str;
        string dec_str;
        double koi_kepmag;
        double koi_kepmag_err;


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
            string sLine = "";
            int i = 0;

            while (sLine != null)
            {
                i++;
                sLine = objReader.ReadLine();

            ultimo_planeta = sLine;
                planetas_leidos[i] = ultimo_planeta;

            }
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

