//
// Copyright (c) 2016, MindFusion LLC - Bulgaria.
//

using System;

using MindFusion.Charting;


namespace IOSSamples
{
    class Generator : Series
    {
        public Generator(int size, double maxX, double maxY)
        {
            this.size = size;
            this.maxX = maxX;
            this.maxY = maxY;
        }

        public double GetValue(int index, int dimension)
        {
            if (dimension == 0)
                return index * maxX / size;

            return maxY / 2 + Math.Sin(Math.PI * index / 360) * maxY / 2;
        }

        public string GetLabel(int index, LabelKinds kind)
        {
            return null;
        }

        public bool IsEmphasized(int index)
        {
            return false;
        }

        public LabelKinds SupportedLabels
        {
            get { return LabelKinds.None; }
        }

        public bool IsSorted(int dimension)
        {
            return dimension == 0;
        }

        public int Size
        {
            get { return size; }
        }

        public int Dimensions
        {
            get { return 2; }
        }

        public string Title { get; set; }

        int size;
        double maxX;
        double maxY;

        public event EventHandler DataChanged;
    }
}

