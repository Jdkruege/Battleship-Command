using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;
using System.Xml;

public class PaperHolder : MonoBehaviour {

    public GameObject samplePaper;
    public ArrayList papers;
    public int index;

    public float xTranslate;

    public void Start()
    {
        papers = new ArrayList();
        index = 0;
    }

    public void GatherPaper(TextAsset xml)
    {
        DestroyChildren();
        papers.Clear();

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

            if(papers.Count > 0)
            {
                DisableChildren(paper);
            }

            papers.Add(paper);
           
        }
    }

    public GameObject CreatePaper(string name, string type, string description, string sceneToLoad)
    {


        GameObject paper = GameObject.Instantiate(samplePaper);

        paper.GetComponent<SpriteRenderer>().sortingLayerName = "Paper";
        paper.GetComponent<SpriteRenderer>().sortingOrder = -1 * papers.Count;

        paper.transform.FindChild("MissionText").gameObject.GetComponent<MeshRenderer>().sortingLayerName = "Paper";
        paper.transform.FindChild("MissionText").gameObject.GetComponent<MeshRenderer>().sortingOrder = -1 * papers.Count;
        paper.transform.FindChild("MissionText").gameObject.GetComponent<TextMesh>().text = "Mission: " + name + "\nMission Type: " + type;

        paper.transform.FindChild("DescriptionText").gameObject.GetComponent<MeshRenderer>().sortingLayerName = "Paper";
        paper.transform.FindChild("DescriptionText").gameObject.GetComponent<MeshRenderer>().sortingOrder = -1 * papers.Count;
        paper.transform.FindChild("DescriptionText").gameObject.GetComponent<TextMesh>().text = description;

        paper.transform.FindChild("AcceptButton").gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Paper";
        paper.transform.FindChild("AcceptButton").gameObject.GetComponent<SpriteRenderer>().sortingOrder = -1 * papers.Count;
        paper.transform.FindChild("AcceptButton").gameObject.GetComponent<AcceptMission>().scene = sceneToLoad;

        return paper;
    }

    public void ForwardAPage()
    {
        if (index == papers.Count - 1) return;

        GameObject paperToMove = (GameObject)papers[index];
        GameObject newPaper = (GameObject)papers[index+1];

        DisableChildren(paperToMove);
        paperToMove.transform.Translate(new Vector3(-1 * xTranslate, 0, 0));

        EnableChildren(newPaper);

        index++;
    }

    public void BackwardAPage()
    {
        if (index == 0) return;

        GameObject paperToMove = (GameObject)papers[index - 1];
        GameObject oldPaper = (GameObject)papers[index];

        EnableChildren(paperToMove);
        paperToMove.transform.Translate(new Vector3(xTranslate, 0, 0));

        DisableChildren(oldPaper);

        index--;
    }

    private void EnableChildren(GameObject paper)
    {
        for (int i = 0; i < paper.transform.childCount; i++)
        {
            paper.transform.GetChild(i).gameObject.SetActive(true);
        }

        //paper.SetActive(true);
    }

    private void DisableChildren(GameObject paper)
    {
        for (int i = 0; i < paper.transform.childCount; i++)
        {
            paper.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    private void DestroyChildren()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
