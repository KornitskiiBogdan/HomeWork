using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace HomeWorkTheme8
{
    public class SerializeDeserialize
    {
        /// <summary>
        /// Сериализация с помощью Xml
        /// </summary>
        /// <param name="organization"></param>
        /// <param name="path"></param>
        static public void SerializeXml(Organization organization, string path)
        {
            XElement myOrganization = new XElement("Organization");
            for (int i = 0; i < organization.Count; i++)
            {
                XElement myDepartament = new XElement("Department");
                XAttribute xAttributeDertamentName = new XAttribute("name", organization[i].Name);
                XAttribute xAttributeDertamentDate = new XAttribute("date", organization[i].DateCreate);

                for (int j = 0; j < organization[i].Count; j++)
                {
                    XElement myWorker = new XElement("Worker");
                    
                    XElement workerName = new XElement("name", organization[i][j].FirstName);
                    
                    XElement workerLastName = new XElement("lastName", organization[i][j].LastName);
                    
                    XElement workerAge = new XElement("age", organization[i][j].Age);
                    
                    XElement workerSalary = new XElement("salary", organization[i][j].Salary);
                    
                    XElement workerNumOfProject = new XElement("numOfProject", organization[i][j].NumOfProject);
                    
                    myWorker.Add(workerName);
                    myWorker.Add(workerLastName);
                    myWorker.Add(workerAge);
                    myWorker.Add(workerSalary);
                    myWorker.Add(workerNumOfProject);
                    myDepartament.Add(myWorker);
                }
                myDepartament.Add(xAttributeDertamentName, xAttributeDertamentDate);
                myOrganization.Add(myDepartament);
            }
            myOrganization.Save(path);
        }
        /// <summary>
        /// Десериализация в Xml
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        static public Organization DeserializeXml(string path)
        {
            string xml = File.ReadAllText(path);

            var dp = XDocument.Parse(xml)
                .Descendants("Organization")
                .Descendants("Department")
                .ToList();
            List<Department> departments = new List<Department>();
            foreach(var elem in dp)
            {
                var ws= elem.Descendants("Worker");
                List<Worker> workers = new List<Worker>();
                foreach(var item in ws)
                {
                    var fN = item.Element("name").Value;
                    var lN = item.Element("lastName").Value;
                    var age = int.Parse(item.Element("age").Value);
                    var salary = int.Parse(item.Element("salary").Value);
                    var numPj = int.Parse(item.Element("numOfProject").Value);
                    Worker worker = new Worker(fN, lN, age, salary, numPj);
                    workers.Add(worker);
                }
                Department department = new Department(workers, elem.Attribute("name").Value, DateTime.Parse(elem.Attribute("date").Value));
                departments.Add(department);
            }
            Organization organization = new Organization(departments);
            return organization;
        }
        /// <summary>
        /// Сериализация с помощью Json
        /// </summary>
        /// <param name="organization"></param>
        /// <param name="path"></param>
        static public void SerializeJson(Organization organization, string path)
        {
            //JObject mainTree = new JObject();

            //JArray arrayDepartment = new JArray();
            //for (int i = 0; i < organization.Count; i++)
            //{
            //    JObject jDepartment = new JObject();

            //    JArray arrayWorker = new JArray();

            //    JObject obj = new JObject();

            //    obj["DateCreate"] = organization[i].DateCreate;
            //    obj["Name"] = organization[i].Name;

            //    arrayWorker.Add(obj);

            //    for (int j = 0; j < organization[i].Count; j++)
            //    {
            //        JObject jWorker = new JObject();
            //        JObject o = new JObject();
            //        o["FirstName"] = organization[i][j].FirstName;
            //        o["LastName"] = organization[i][j].LastName;
            //        o["ID"] = organization[i][j].ID;
            //        o["NumDepartment"] = organization[i][j].NameDepartament;
            //        o["Age"] = organization[i][j].Age;
            //        o["Salary"] = organization[i][j].Salary;
            //        o["NumOfProject"] = organization[i][j].NumOfProject;
            //        jWorker["Worker"] = o;
            //        arrayWorker.Add(jWorker);
            //    }

            //    jDepartment[$"Department"] = arrayWorker;

            //    arrayDepartment.Add(jDepartment);

            //}
            //mainTree["Organization"] = arrayDepartment;

            //string jsonString = mainTree.ToString();

            //File.WriteAllText(path, jsonString);

            string json = JsonConvert.SerializeObject(organization);
            File.WriteAllText(path, json);
        }
        /// <summary>
        /// Десериализация из Json
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        static public Organization DeserializeJson(string path)
        {
            string jsonText = File.ReadAllText(path);
            var organization = JsonConvert.DeserializeObject<Organization>(jsonText);
            //var json = JObject.Parse(jsonText);
            //var departmens = json["Organization"].Children().ToString();
            //var text = JObject.Parse(departmens);
            //var worker = text["Worker"].Children().ToList();




            return organization;
        }

    }
}
