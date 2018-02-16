/**
 * Implementation of the net.sf.geographiclib.PolygonResult class
 *
 * Copyright (c) Charles Karney (2013) <charles@karney.com> and licensed
 * under the MIT/X11 License.  For more information, see
 * http://geographiclib.sourceforge.net/
 **********************************************************************/
namespace GeographicLib
{

    /**
     * A container for the results from PolygonArea.
     **********************************************************************/
    public readonly struct PolygonResult
    {
        /**
         * The number of vertices in the polygon
         **********************************************************************/
        public int Num { get; }
        /**
         * The Perimeter of the polygon or the length of the polyline (meters).
         **********************************************************************/
        public double Perimeter { get; }
        /**
         * The Area of the polygon (meters<sup>2</sup>).
         **********************************************************************/
        public double Area { get; }
        /**
         * Constructor
         * <p>
         * @param num the number of vertices in the polygon.
         * @param perimeter the Perimeter of the polygon or the length of the
         *   polyline (meters).
         * @param area the Area of the polygon (meters<sup>2</sup>).
         **********************************************************************/
        public PolygonResult(int num, double perimeter, double area)
        {
            this.Num = num;
            this.Perimeter = perimeter;
            this.Area = area;
        }
    }
}