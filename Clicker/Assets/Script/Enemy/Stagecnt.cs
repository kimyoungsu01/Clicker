using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Stagecnt : MonoBehaviour
{
    public int stagecnt = 0;
    public int Maxstage = 29;
    public int dungeonstagecnt = 1;
    public int Maxdungeonstage = 10;
    Enemydata enemydata;
    public TMP_Text stageText;
    public TMP_Text dungeonstage;
    public TMP_Text dungeonname;

   void Start()
   {
         stageText.text = (stagecnt+1).ToString();
         
    }

    public void UpdateStage()
    {
        if (stagecnt >= Maxstage)
        {
            stagecnt = 0;
            //dungeonstagecnt = 0;
        }
        stagecnt++;        
        //dungeonstagecnt++;
        //dungeonstage.text = dungeonstagecnt.ToString();
        stageText.text = (stagecnt+1).ToString();
       
    }
     public void DungeonStage()
    {
        if (dungeonstagecnt >= Maxdungeonstage)
        {
            dungeonstagecnt = 0;
        }        
        dungeonstagecnt++;
        dungeonstage.text = dungeonstagecnt.ToString();
    }      

}
