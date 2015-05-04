using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;
using System.Xml;

public class PaperHolder : MonoBehaviour {

    public GameObject samplePaper;
    public ArrayList papers;
    public int index;

    public void Start()
    {
        papers = new ArrayList();
        index = 0;
    }

    public void GatherPaper(TextAsset xml)
    {
        DestroyChildren();

        XmlDocument doc = new XmlDocument();
        doc.LoadXml(xml.text);

        foreach(XmlNode node in doc.DocumentElement.ChildNodes)
        {

            string name = node.SelectSingleNode("Name").InnerText;
            string type = node.SelectSingleNode("Type").InnerText;
            string description = node.SelectSingleNode("Description").InnerText.Trim();
            string scene = node.SelectSingleNode("Scene").InnerText;

            GameObject paper = CreatePaper(name, type, description, scene);
            paper.transform.position = transform.position;
            paper.transform.parent = transform;

            papers.Add(paper);
           
        }
    }

    public void DestroyChildren()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }

    public GameObject CreatePaper(string name, string type, string description, string sceneToLoad)
    {
        GameObject paper = GameObject.Instantiate(samplePaper);

        paper.transform.FindChild("MissionText").GetComponent<MeshRenderer>().sortingLayerName = "Paper";
        paper.transform.FindChild("MissionText").GetComponent<TextMesh>().text = "Mission: " + name + "\nMission Type: " + type;
            
        paper.transform.FindChild("DescriptionText").GetComponent<MeshRenderer>().sortingLayerName = "Paper";
        paper.transform.FindChild("DescriptionText").GetComponent<TextMesh>().text = description;
        
        paper.transform.FindChild("AcceptButton").GetComponent<AcceptMission>().scene = sceneToLoad;

        return paper;
    }

    public void ForwardAPage()
    {
        //Flip to next page till end
        Debug.Log("Forward!");
    }

    public void BackwardAPage()
    {
        //Flip to last page till front
        Debug.Log("Backward!");
    }
}
