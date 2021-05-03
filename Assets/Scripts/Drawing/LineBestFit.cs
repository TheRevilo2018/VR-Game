using MathNet.Numerics.LinearAlgebra;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneOfBestFit
{
    class BestFit
    {
        List<float[]> points;
        Vector3 centroid = new Vector3();
        Vector3 normalVector = new Vector3();
         
        public BestFit(List<float[]> inputPoints)
        {
            points = inputPoints;
            findCentroid();
            subCentroid();
            findPlane();
        }

        public BestFit(List<Vector3> inputPoints)
        {
            points = convertToFloats(inputPoints);
            findCentroid();
            subCentroid();
            findPlane();
        }

        public Vector3 getNormal()
        {
            return normalVector;
        }

        public Vector3 getCentroid()
        {
            return centroid;
        }

        List<float[]> convertToFloats(List<Vector3> input)
        {
            List<float[]> convertTemp = new List<float[]>();

            foreach(Vector3 point in input)
            {
                convertTemp.Add(new float[3] { point.x, point.y, point.z });
            }

            return convertTemp;
        }

        void findCentroid()
        {
            foreach (float[] point in points)
            {
                centroid[0] += point[0];
                centroid[1] += point[1];
                centroid[2] += point[2];
            }

            centroid[0] /= points.Count;
            centroid[1] /= points.Count;
            centroid[2] /= points.Count;
        }

        void subCentroid()
        {
            foreach (float[] point in points)
            {
                point[0] -= centroid[0];
                point[1] -= centroid[1];
                point[2] -= centroid[2];
            }
        }

        void findPlane()
        {
            Matrix<float> pointMatrix = Matrix<float>.Build.DenseOfColumns(points);

            var temp = pointMatrix.Svd().U.ToArray();

            normalVector[0] = temp[2, 0];
            normalVector[1] = temp[2, 1];
            normalVector[2] = temp[2, 2];
        }
    }
}
