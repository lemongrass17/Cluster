using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cluster
{
    class PointXY
    {
        private double x;
        private double y;
        private int cluster = 0;

        public PointXY()
        {
            this.x = 0;
            this.y = 0;
        }
        public PointXY(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public void setX(double x)
        {
            this.x = x;
        }

        public double getX()
        {
            return x;
        }

        public void setY(double y)
        {
            this.y = y;
        }

        public double getY()
        {
            return y;
        }

        public void setCluster(int cluster)
        {
            this.cluster = cluster;
        }

        public int getCluster()
        {
            return cluster;
        }
    }
}
