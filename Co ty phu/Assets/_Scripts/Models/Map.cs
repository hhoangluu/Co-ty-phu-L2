using Firebase.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{

    public static Map Current;
    public GameObject plotVerticalPrefap;
    public GameObject plotHorizontalPrefap;
    public GameObject bigPlotPrefap;
    public GameObject Deal;
    public GameObject DealWonders;
    public GameObject DealMinigame;
    public GameObject DealWorldCup;
    public GameObject DealChance;
    public GameObject DealPrison;
    public GameObject DealTravel;
    public GameObject DealHonDao;
    public GameObject DealThue;
    public GameObject DealStart;

    public Building[] Ar_BuidingModel;

    //public Building[] Ar_BuidingModel;



    public List<BaseItem> items;


    public void pushBuilding(int pos)
    {
        BuildingInfo temp = new BuildingInfo();
        temp.Level = Ar_BuidingModel[pos].Level;
        temp.Fees = Ar_BuidingModel[pos].Fees;
        temp.Owner = Ar_BuidingModel[pos].Owner.ToString();
        temp.Position = pos;

        GameInfoModel.mDatabaseRef.Child("Game").Child(GameInfoModel.IdGame).Child("Buildings").Child(pos.ToString()).SetRawJsonValueAsync(JsonUtility.ToJson(temp));

    }


    private float plot_size = -1;
    public float PlotSize
    {
        get
        {
            if (plot_size < 0)
                plot_size = plotHorizontalPrefap.GetComponentInChildren<Plot>().SIZEX;
            return plot_size;
        }
    }

    private float botleft_margin = -1;
    public float BotLeftMargin
    {
        get
        {
            if (botleft_margin < 0)
                botleft_margin = -4.5f * plotHorizontalPrefap.GetComponentInChildren<Plot>().SIZEX;
            return botleft_margin;
        }
    }

    private float topright_margin = -1;
    public float TopRightMargin
    {
        get
        {
            if (topright_margin < 0)
                topright_margin = 4.5f * plotHorizontalPrefap.GetComponentInChildren<Plot>().SIZEX;
            return topright_margin;
        }
    }


    void Awake()
    {
        Current = this;
        Current.items = new List<BaseItem>();
        Current.Ar_BuidingModel = new Building[32];
        float jump = 100;
        float org = 1000;
        for (int i = 0; i < 32; i++)
        {
            FirebaseDatabase.DefaultInstance
            .GetReference("Game").Child(GameInfoModel.IdGame).Child("Buildings").Child(i.ToString())
            .ValueChanged += HandleValueChanged;
            Current.Ar_BuidingModel[i] = new Building(i);

            if (i == 0)
            {
                Current.Ar_BuidingModel[i].Cityname = "XUẤT PHÁT";
            }
            else if (i == 2)
            {
                Current.Ar_BuidingModel[i].Cityname = "MINI GAME";
            }
            else if (i == 8)
            {
                Current.Ar_BuidingModel[i].Cityname = "HOANG ĐẢO";
            }
            else if (i == 16)
            {
                Current.Ar_BuidingModel[i].Cityname = "WORLD CUOP";
            }
            else if (i == 24)
            {
                Current.Ar_BuidingModel[i].Cityname = "DU LỊCH";
            }
            else if (i == 30)
            {
                Current.Ar_BuidingModel[i].Cityname = "THUẾ";
            }
            else if (i == 12 || i == 20 || i == 28)
            {
                Current.Ar_BuidingModel[i].Cityname = "CƠ HỘI";
            }
            else if (i == 4 || i == 9 || i == 14 || i == 18 || i == 25)
            {
                if (i == 4)
                {
                    Current.Ar_BuidingModel[i].Cityname = "OKINAWA";
                }
                else if (i == 9)
                {
                    Current.Ar_BuidingModel[i].Cityname = "BALI";
                }
                else if (i == 14)
                {
                    Current.Ar_BuidingModel[i].Cityname = "HAWAII";
                }
                else if (i == 18)
                {
                    Current.Ar_BuidingModel[i].Cityname = "PHUKET";
                }
                else
                {
                    Current.Ar_BuidingModel[i].Cityname = "TAHITI";
                }
                Current.Ar_BuidingModel[i].Price = org + jump;
                org += jump;
            }
            else
            {

                if (i == 1)
                {
                    Current.Ar_BuidingModel[i].Cityname = "OKINAWA";
                }
                else if (i == 3)
                {
                    Current.Ar_BuidingModel[i].Cityname = "BALI";
                }
                else if (i == 5)
                {
                    Current.Ar_BuidingModel[i].Cityname = "CAIPRO";
                }
                else if (i == 6)
                {
                    Current.Ar_BuidingModel[i].Cityname = "PHUKET";
                }
                else if (i == 6)
                {
                    Current.Ar_BuidingModel[i].Cityname = "SEOUL";
                }
                else if (i == 6)
                {
                    Current.Ar_BuidingModel[i].Cityname = "PHUKET";
                }
                else if (i == 6)
                {
                    Current.Ar_BuidingModel[i].Cityname = "SINGAPORE";
                }
                else if (i == 6)
                {
                    Current.Ar_BuidingModel[i].Cityname = "SAOPAULO";
                }
                else if (i == 6)
                {
                    Current.Ar_BuidingModel[i].Cityname = "PRAGUE";
                }
                else if (i == 6)
                {
                    Current.Ar_BuidingModel[i].Cityname = "BERLIN";
                }
                else if (i == 6)
                {
                    Current.Ar_BuidingModel[i].Cityname = "MOSCOW";
                }
                else if (i == 6)
                {
                    Current.Ar_BuidingModel[i].Cityname = "GENEVA";
                }
                else if (i == 6)
                {
                    Current.Ar_BuidingModel[i].Cityname = "ROME";
                }
                else if (i == 6)
                {
                    Current.Ar_BuidingModel[i].Cityname = "LONDON";
                }
                else if (i == 6)
                {
                    Current.Ar_BuidingModel[i].Cityname = "PARIS";
                }
                else if (i == 6)
                {
                    Current.Ar_BuidingModel[i].Cityname = "NEW YORK";
                }
                else if (i == 6)
                {
                    Current.Ar_BuidingModel[i].Cityname = "PHUKET";
                }
                else
                {
                    Current.Ar_BuidingModel[i].Cityname = "HÀ NỘI";
                }
                Current.Ar_BuidingModel[i].Price = org + jump;
                org += jump;
            }
        }
    }
    public Vector3 basePosition;
    private Plot[] _plots;
    private object mapModel;

    public Plot[] Plots
    {
        get { return _plots; }

    }
    [ContextMenu("check")]
    public void Check()
    {
        Init();
    }
    //[ContextMenu("InitBuilding1-1")]

    public void InitBuilding1(int id, string color)
    {
        //items = new List<BaseItem>();
        GameObject Building1 = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Items/Building1-" + color)) as GameObject;
        Building1.transform.parent = this.transform.GetChild(1);
        Building1.name = id.ToString();
        Building b1 = Building1.GetComponent<Building>();
        items.Add(b1);
        b1.SetBuilding1LocationById(id);
    }
    public void deleteBuilding(int id)
    {
        GameObject Building = null;
        for (int i = 0; i < items.Count; i++)
        {

            Building = transform.GetChild(1).GetChild(i).gameObject;
            if (Building.name == id.ToString())
            {
                Destroy(Building);
            }
        }
    }
    public void InitBuilding2(int id, string color)
    {

        GameObject Building2 = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Items/Building2-" + color)) as GameObject;
        Building2.transform.parent = this.transform.GetChild(1);
        Building2.name = id.ToString();
        Building b2 = Building2.GetComponent<Building>();
        items.Add(b2);
        b2.SetBuilding2LocationById(id);
    }
    public void InitBuilding3(int id, string color)
    {
        //items = new List<BaseItem>();
        GameObject Building3 = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Items/Building3-" + color)) as GameObject;
        Building3.transform.parent = this.transform.GetChild(1);
        Building3.name = id.ToString();
        Building b3 = Building3.GetComponent<Building>();
        items.Add(b3);
        b3.SetBuilding3LocationById(id);
    }

    public void InitWonders(int id, string color)
    {
        //items = new List<BaseItem>();
        GameObject Building3 = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Items/" + id + "-" + color)) as GameObject;
        Building3.transform.parent = this.transform.GetChild(1);
        Building3.name = id.ToString();
        Building b3 = Building3.GetComponent<Building>();
        items.Add(b3);
        b3.SetWondersLocationById(id);
    }


    public void Init()
    {
        _plots = new Plot[32];
        for (int i = 0; i < 32; i++)
        {

            GameObject c = null;
            if (i % 8 == 0)
            {
                c = GameObject.Instantiate(bigPlotPrefap, CanculatePosition(i), bigPlotPrefap.transform.rotation) as GameObject;

            }
            else if ((i > 8 && i < 16) || (i < 32 && i > 24))
            {
                c = GameObject.Instantiate(plotHorizontalPrefap, CanculatePosition(i), plotHorizontalPrefap.transform.rotation) as GameObject;
            }
            else
            {
                c = GameObject.Instantiate(plotVerticalPrefap, CanculatePosition(i), plotVerticalPrefap.transform.rotation) as GameObject;
            }


            c.transform.parent = this.transform.GetChild(0);
            //  c.GetComponent<Collider>().tag = "Plot";
            _plots[i] = c.GetComponentInChildren<Plot>();
            _plots[i].name = "plot " + i;

            // set color for plot
            if (i == 1 || i == 3)
            {
                _plots[i].Color = EPlotColor.COLOR1;
            }
            else if (i == 5 || i == 6 || i == 7)
            {
                _plots[i].Color = EPlotColor.COLOR2;
            }
            else if (i == 10 || i == 11)
            {
                _plots[i].Color = EPlotColor.COLOR3;
            }
            else if (i == 13 || i == 15)
            {
                _plots[i].Color = EPlotColor.COLOR4;
            }
            else if (i == 17 || i == 19)
            {
                _plots[i].Color = EPlotColor.COLOR5;
            }
            else if (i == 21 || i == 22 || i == 23)
            {
                _plots[i].Color = EPlotColor.COLOR6;
            }
            else if (i == 26 || i == 27)
            {
                _plots[i].Color = EPlotColor.COLOR7;
            }
            else if (i == 29 || i == 31)
            {
                _plots[i].Color = EPlotColor.COLOR8;
            }
            else
            {
                _plots[i].Color = EPlotColor.WHITE;
            }
            //_plots[i].count = 1;






        }
    }



    public Vector3 CanculatePosition(int i)
    {
        float SIZE = plotHorizontalPrefap.GetComponentInChildren<Plot>().SIZEX;
        float SIZEY = plotHorizontalPrefap.GetComponentInChildren<Plot>().SIZEY;
        float SIZEBig = bigPlotPrefap.GetComponent<Plot>().SIZEBig;

        //Debug.Log(SIZE);
        Vector3 base1 = new Vector3(basePosition.x, 0, basePosition.z);
        Vector3 base2 = new Vector3(basePosition.x, 0, basePosition.z + 8 * SIZE);
        Vector3 base3 = new Vector3(basePosition.x + 8 * SIZE, 0, 3.5f * SIZE + 0.5f * SIZEBig);
        Vector3 base4 = new Vector3(3.5f * SIZE + 0.5f * SIZEBig, 0, basePosition.z);
        if (i < 8)
        {
            if (i == 0)
            {
                return new Vector3(-3.5f * SIZE - 0.5f * SIZEBig, base1.y, -3.5f * SIZE - 0.5f * SIZEBig);
            }
            //return new Vector3(base1.x -  0.5f*SIZEY, base1.y, base1.z + i * SIZE);
            //Debug.Log(base1.z + (i - 1) * SIZE + 0.5f * SIZEBig);
            return new Vector3(-4.5f * SIZE, base1.y, base1.z + (i - 1) * SIZE + 0.5f * SIZEBig + 0.5f * SIZE);
            Debug.Log(base1.z + (i - 1) * SIZE + 0.5f * SIZEBig);
        }
        else if (i < 16)
        {
            if (i == 8)
            {
                return new Vector3(-3.5f * SIZE - 0.5f * SIZEBig, base2.y, 3.5f * SIZE + 0.5f * SIZEBig);
            }

            return new Vector3(base2.x + ((i % 8) - 1) * SIZE + 0.5f * SIZEBig + 0.5f * SIZE, base2.y, 4.5f * SIZE);
        }
        else if (i < 24)
        {
            if (i == 16)
            {
                return new Vector3(3.5f * SIZE + 0.5f * SIZEBig, base3.y, 3.5f * SIZE + 0.5f * SIZEBig);
            }
            var a = base3.z - ((i % 8) - 1) * SIZE - 0.5f * SIZEBig - 0.5f * SIZE;
            //  Debug.Log(a);
            //  Debug.Log("base 3" + base3);
            return new Vector3(4.5f * SIZE, base3.y, a);
        }
        else
        {
            if (i == 24)
            {
                return new Vector3(3.5f * SIZE + 0.5f * SIZEBig, base4.y, -3.5f * SIZE - 0.5f * SIZEBig);
            }
            return new Vector3(base4.x - ((i % 8) - 1) * SIZE - 0.5f * SIZEBig - 0.5f * SIZE, base4.y, -4.5f * SIZE);
        }
    }

    public void ShowDeal(int pos)
    {
        //Deal.active = true;
        #region từng trường hợp
        if (pos == 0)
        {
            DealStart.active = true;
            ShowWorldCup();
        }
        else if (pos == 2)
        {
            DealMinigame.active = true;
        }
        else if (pos == 8)
        {
            DealPrison.active = true;
            GameController.instance.PrisonWait3Turn();
        }
        else if (pos == 16)
        {
            DealWorldCup.active = true;
            ShowWorldCup();
        }
        else if (pos == 24)
        {
            DealTravel.active = true;
            GameController.instance.PrisonWait3Turn();
        }
        else if (pos == 4 || pos == 9 || pos == 14 || pos == 18 || pos == 25)
        {
            DealHonDao.active = true;
        }
        else if (pos == 12 || pos == 20 || pos == 28)
        {
            DealChance.active = true;
        }
        else if (pos == 30)
        {
            DealThue.active = true;
        }
        else
        {
            if (Ar_BuidingModel[pos].Level == 3)
            {
                DealWonders.active = true;
            }
            else if (Ar_BuidingModel[pos].Level < 3)
            {
                Deal.active = true;
            }
        }
        #endregion

    }

    public void hideDeal(int pos)
    {
        //Deal.active = false;

        #region Từng trường hợp
        if (pos == 0)
        {
            DealStart.active = false;
        }
        else if (pos == 2)
        {
            DealMinigame.active = false;
        }
        else if (pos == 8)
        {
            DealPrison.active = false;
        }
        else if (pos == 16)
        {
            DealWorldCup.active = false;
        }
        else if (pos == 24)
        {
            DealTravel.active = false;
        }
        else if (pos == 4 || pos == 9 || pos == 14 || pos == 18 || pos == 25)
        {
            DealHonDao.active = false;
        }
        else if (pos == 12 || pos == 20 || pos == 28)
        {
            DealChance.active = false;
        }
        else if (pos == 30)
        {
            DealThue.active = false;
        }
        else
        {
            if (Ar_BuidingModel[pos].Level == 4)
            {
                DealWonders.active = false;
            }
            else if (Ar_BuidingModel[pos].Level < 4)
            {
                Deal.active = false;
            }
        }
        #endregion

    }

    private void ShowWorldCup()
    {
        GameController.instance.NextTurn();
        //   WorldCup = -1;
        //   StartCoroutine(NhanDoi());
    }
    private void ShowTravel()
    {
        GameController.instance.PrisonWait3Turn();
        // Travel = -1;
        // StartCoroutine(Didulich());
    }
    void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {

        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        DataSnapshot snapshot = args.Snapshot;
        // neeus ddung turn thi moi gan du lieu
        for (int i = 0; i < 32; i++)
        {
            //Debug.Log("i = " + i);
            if (i == int.Parse(snapshot.Key))
            {
                int oldLevel = Ar_BuidingModel[i].Level;
                Debug.Log("int.Parse(snapshot.Key) = " + int.Parse(snapshot.Key));

                Ar_BuidingModel[i].Fees = float.Parse(snapshot.Child("Fees").Value.ToString());
                Ar_BuidingModel[i].Level = int.Parse(snapshot.Child("Level").Value.ToString());
                Ar_BuidingModel[i].Position = int.Parse(snapshot.Child("Position").Value.ToString());
                if (snapshot.Child("Owner").Value.ToString() == "RED")
                {
                    Debug.Log("owner = RED");
                    Ar_BuidingModel[i].Owner = EPlayer.RED;
                }
                else if (snapshot.Child("Owner").Value.ToString() == "BLUE")
                {
                    Debug.Log("owner = BLUE");
                    Ar_BuidingModel[i].Owner = EPlayer.BLUE;
                }
                else if (snapshot.Child("Owner").Value.ToString() == "YELLOW")
                {
                    Debug.Log("owner = YELLOW");
                    Ar_BuidingModel[i].Owner = EPlayer.YELLOW;
                }
                else
                {
                    Debug.Log("owner = GREEN");
                    Ar_BuidingModel[i].Owner = EPlayer.GREEN;
                }

                if (i == 4 || i == 9 || i == 14 || i == 18 || i == 25)  //hòn đảo
                {
                    if (Ar_BuidingModel[i].Level == 0)
                    {
                        deleteBuilding(i);
                    }
                    else if (Ar_BuidingModel[i].Level == 1)
                    {
                        Debug.Log("xay hon dao 1");
                        InitBuilding1(i, Ar_BuidingModel[i].Owner.ToString());
                    }
                    else
                    {
                        deleteBuilding(i);
                        Debug.Log("xay hon dao 2");
                        InitWonders(i, Ar_BuidingModel[i].Owner.ToString());
                    }
                }
                else
                {
                    if (Ar_BuidingModel[i].Level == 0)
                    {
                        deleteBuilding(i);
                    }
                    else if (Ar_BuidingModel[i].Level == 1)
                    {
                        Debug.Log("xay nha 1");
                        InitBuilding1(i, Ar_BuidingModel[i].Owner.ToString());
                    }
                    else if (Ar_BuidingModel[i].Level == 2)
                    {
                        Debug.Log("xay nha 2");
                        if (oldLevel == 0)
                        {
                            InitBuilding1(i, Ar_BuidingModel[i].Owner.ToString());
                            InitBuilding2(i, Ar_BuidingModel[i].Owner.ToString());
                        }
                        else
                        {
                            InitBuilding2(i, Ar_BuidingModel[i].Owner.ToString());
                        }
                    }
                    else if (Ar_BuidingModel[i].Level == 3)
                    {
                        if (oldLevel == 0)
                        {
                            InitBuilding1(i, Ar_BuidingModel[i].Owner.ToString());
                            InitBuilding2(i, Ar_BuidingModel[i].Owner.ToString());
                            InitBuilding3(i, Ar_BuidingModel[i].Owner.ToString());
                        }
                        else if (oldLevel == 1)
                        {
                            InitBuilding2(i, Ar_BuidingModel[i].Owner.ToString());
                            InitBuilding3(i, Ar_BuidingModel[i].Owner.ToString());
                        }
                        else
                        {
                            InitBuilding3(i, Ar_BuidingModel[i].Owner.ToString());
                        }
                        Debug.Log("xay nha 3");
                    }
                    else
                    {
                        deleteBuilding(i);
                        Debug.Log("xay nha ki quan");
                        InitWonders(i, Ar_BuidingModel[i].Owner.ToString());
                    }
                }



            }

        }



    }
}
