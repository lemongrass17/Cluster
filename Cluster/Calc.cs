using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cluster
{
    class Calc
    {
        private String file1 = "C: /Users/Богдан/source/repos/Cluster/s1.txt";
        private String file2 = "C: /Users/Богдан/source/repos/Cluster/s2.txt";
        private String file3 = "C: /Users/Богдан/source/repos/Cluster/s3.txt";
        private String file4 = "C: /Users/Богдан/source/repos/Cluster/s4.txt";
        private int n;
        private int set_num;
        private PointXY[] centers;
        private List <PointXY> points;
        private bool changed = true;

        public Calc(int n, int set_num)
        {
            this.n = n;
            this.set_num = set_num;
            this.centers = new PointXY[n];
            this.points = new List <PointXY>();

        }

        public void ReadFile()
        {
            String f = "";
            if (set_num == 1)
            {
                f = file1;
            }
            else if (set_num == 2)
            {
                f = file2;
            }
            else if (set_num == 3)
            {
                f = file3;
            }
            else if (set_num == 4)
            {
                f = file4;
            }
            StreamReader fs = new StreamReader(f);
            string s = "";
            Regex r = new Regex(@"\s+");
            while (true)
            {
                s = fs.ReadLine();
                if (s == null)
                {
                    break;
                }
                s = r.Replace(s.Trim(), @" ");
                points.Add(new PointXY(Convert.ToDouble(s.Split(' ')[0]), Convert.ToDouble(s.Split(' ')[1])));
            }
        }

        public void Centers()
        {
            Random r = new Random();
            for (int i = 0; i < n; i++)
            {
                int ind = r.Next(0, points.Count - 1);
                centers[i] = new PointXY();
                centers[i].setX(points[ind].getX());
                centers[i].setY(points[ind].getY());
                centers[i].setCluster(i + 1);
            }
        }

        public void ReCenters()
        {
            int[] count = new int[n];
            for (int i = 0; i < n; i++)
            {
                centers[i].setX(0);
                centers[i].setY(0);
                //centers[i].setCluster(i + 1);
                count[i] = 0;
            }
            for (int i = 0; i < points.Count; i++)
            {
                centers[(points[i].getCluster()) - 1].setX(centers[(points[i].getCluster()) - 1].getX() + points[i].getX());
                centers[(points[i].getCluster()) - 1].setY(centers[(points[i].getCluster()) - 1].getY() + points[i].getY());
                count[(points[i].getCluster()) - 1] = count[(points[i].getCluster()) - 1] + 1;
            }
            for (int i = 0; i < centers.Length; i++)
            {
                centers[i].setX(centers[i].getX() / count[i]);
                centers[i].setY(centers[i].getY() / count[i]);
            }
        }

        public double Dist(PointXY cent, PointXY p)
        {
            return Math.Sqrt(Math.Pow((cent.getX() - p.getX()), 2) + Math.Pow((cent.getY() - p.getY()), 2));
        }

        public void Sort()
        {
            double[] dist = new double[n];
            changed = false;
            for (int i = 0; i < points.Count; i++)
            {
                double min = double.PositiveInfinity;
                int ind_min = -5;
                for (int j = 0; j < n; j++)
                {
                    dist[j] = Dist(centers[j], points[i]);
                    if (dist[j] < min)
                    {
                        min = dist[j];
                        ind_min = j;
                    }
                }
                if (points[i].getCluster() != (ind_min + 1))
                {
                    points[i].setCluster(ind_min + 1);
                    changed = true;
                }
            }
        }

        public List<PointXY> GetList()
        {
            ReadFile();
            Centers();
            while (changed == true)
            {
                Sort();
                ReCenters();
            }
            
            return points;
        }
    }
}
