/**
 * Implementation of the net.sf.geographiclib.GeodesicData class
 *
 * Copyright (c) Charles Karney (2013) <charles@karney.com> and licensed
 * under the MIT/X11 License.  For more information, see
 * http://geographiclib.sourceforge.net/
 **********************************************************************/
using System;
namespace GeographicLib
{

    /**
     * The results of geodesic calculations.
     *
     * This is used to return the results for a geodesic between point 1
     * (<i>lat1</i>, <i>lon1</i>) and point 2 (<i>lat2</i>, <i>lon2</i>).  Fields
     * that have not been set will be filled with Double.NaN.  The returned
     * GeodesicData objects always include the parameters provided to {@link
     * Geodesic#Direct(double, double, double, double) Geodesic.Direct} and {@link
     * Geodesic#Inverse(double, double, double, double) Geodesic.Inverse} and it
     * always includes the field <i>a12</i>.
     **********************************************************************/
    public class GeodesicData
    {
        /// <summary>
        /// latitude of point 1 (degrees).
        /// </summary>
        public double lat1 { get; set; }

        /// <summary>
        /// longitude of point 1 (degrees).
        /// </summary>
        public double lon1 { get; set; }

        /// <summary>
        /// azimuth at point 1 (degrees).
        /// </summary>
        public double azi1 { get; set; }

        /// <summary>
        /// latitude of point 2 (degrees).
        /// </summary>
        public double lat2 { get; set; }

        /// <summary>
        /// longitude of point 2 (degrees).
        /// </summary>
        public double lon2 { get; set; }

        /// <summary>
        /// azimuth at point 2 (degrees).
        /// </summary>
        public double azi2 { get; set; }

        /// <summary>
        /// distance between point 1 and point 2 (meters).
        /// </summary>
        public double s12 { get; set; }

        /// <summary>
        /// arc length on the auxiliary sphere between point 1 and point 2 (degrees).
        /// </summary>
        public double a12 { get; set; }

        /// <summary>
        /// reduced length of geodesic (meters).
        /// </summary>
        public double m12 { get; set; }

        /// <summary>
        /// geodesic scale of point 2 relative to point 1 (dimensionless).
        /// </summary>
        public double M12 { get; set; }

        /// <summary>
        /// geodesic scale of point 1 relative to point 2 (dimensionless).
        /// </summary>
        public double M21 { get; set; }

        /// <summary>
        /// Area under the geodesic (meters<sup>2</sup>).
        /// </summary>
        public double S12 { get; set; }

        /// <summary>
        /// Initialize all the fields to Double.NaN.
        /// </summary>
        public static GeodesicData NaN
        {
            get
            {
                var g = new GeodesicData();
                g.lat1 = g.lon1 = g.azi1 = g.lat2 = g.lon2 = g.azi2 = g.s12 
                    = g.a12 = g.m12 = g.M12 = g.M21 = g.S12 = Double.NaN;
                return g;
            }
        }
    }
}