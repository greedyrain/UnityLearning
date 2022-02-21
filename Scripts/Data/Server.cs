using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Server
{
    [XmlAttribute]
    public int id;
    [XmlAttribute]
    public string serverName;
    [XmlAttribute]
    public int state;
    [XmlAttribute]
    public bool isNew;
}