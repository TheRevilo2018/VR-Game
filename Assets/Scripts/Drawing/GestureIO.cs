using System.IO;
using System.Collections.Generic;
using System.Xml;
using Unity;
using UnityEngine;

namespace PDollarGestureRecognizer
{
    public class GestureIO
    {
        public static List<Gesture> LoadTemplates(string path)
        {
            List<Gesture> gestures = new List<Gesture>();
            string[] gestureFiles = Directory.GetFiles(path, "*.xml");
            foreach (string file in gestureFiles)
            gestures.Add(GestureIO.ReadGesture(file));
            return gestures;
        }

        /// <summary>
        /// Reads a multistroke gesture from an XML file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static Gesture ReadGesture(string fileName)
        {
            List<Point> points = new List<Point>();
            XmlTextReader xmlReader = null;
            int currentStrokeIndex = -1;
            string gestureName = "";
            try
            {
                xmlReader = new XmlTextReader(File.OpenText(fileName));
                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType != XmlNodeType.Element) continue;
                    switch (xmlReader.Name)
                    {
                        case "Gesture":
                            gestureName = xmlReader["Name"];
                            if (gestureName.Contains("~")) // '~' character is specific to the naming convention of the MMG set
                                gestureName = gestureName.Substring(0, gestureName.LastIndexOf('~'));
                            if (gestureName.Contains("_")) // '_' character is specific to the naming convention of the MMG set
                                gestureName = gestureName.Replace('_', ' ');
                            break;
                        case "Stroke":
                            currentStrokeIndex++;
                            break;
                        case "Point":
                            points.Add(new Point(
                                float.Parse(xmlReader["X"]),
                                float.Parse(xmlReader["Y"]),
                                currentStrokeIndex
                            ));
                            break;
                    }
                }
            }
            finally
            {
                if (xmlReader != null)
                    xmlReader.Close();
            }
            return new Gesture(points.ToArray(), gestureName);
        }

        public static void writeTemplates(Gesture[] gestures, string path)
        {
            foreach (Gesture gesture in gestures)
            {
                Debug.Log(path + gesture.Name);
                WriteGesture(gesture.Points, gesture.Name, path + gesture.Name);
            }
        }

        /// <summary>
        /// Writes a multistroke gesture to an XML file
        /// </summary>
        public static void WriteGesture(Point[] points, string gestureName, string fileName)
        {
            fileName += ".xml";
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                sw.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\" standalone=\"yes\"?>");
                sw.WriteLine("<Gesture Name = \"{0}\">", gestureName);
                int currentStroke = -1;
                for (int i = 0; i < points.Length; i++)
                {
                    if (points[i].StrokeID != currentStroke)
                    {
                        if (i > 0)
                            sw.WriteLine("\t</Stroke>");
                        sw.WriteLine("\t<Stroke>");
                        currentStroke = points[i].StrokeID;
                    }

                    sw.WriteLine("\t\t<Point X = \"{0}\" Y = \"{1}\" T = \"0\" Pressure = \"0\" />",
                        points[i].X, points[i].Y
                    );
                }
                sw.WriteLine("\t</Stroke>");
                sw.WriteLine("</Gesture>");
            }
        }
    }
}