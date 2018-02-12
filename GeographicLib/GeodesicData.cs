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
    public sealed class GeodesicData
    {
        /// <summary>
        /// latitude of point 1 (degrees).
        /// </summary>
        public double lat1;

        /// <summary>
        /// longitude of point 1 (degrees).
        /// </summary>
        public double lon1;

        /// <summary>
        /// azimuth at point 1 (degrees).
        /// </summary>
        public double azi1;

        /// <summary>
        /// latitude of point 2 (degrees).
        /// </summary>
        public double lat2;

        /// <summary>
        /// longitude of point 2 (degrees).
        /// </summary>
        public double lon2;

        /// <summary>
        /// azimuth at point 2 (degrees).
        /// </summary>
        public double azi2;

        /// <summary>
        /// distance between point 1 and point 2 (meters).
        /// </summary>
        public double s12;

        /// <summary>
        /// arc length on the auxiliary sphere between point 1 and point 2 (degrees).
        /// </summary>
        public double a12;

        /// <summary>
        /// reduced length of geodesic (meters).
        /// </summary>
        public double m12;

        /// <summary>
        /// geodesic scale of point 2 relative to point 1 (dimensionless).
        /// </summary>
        public double M12;

        /// <summary>
        /// geodesic scale of point 1 relative to point 2 (dimensionless).
        /// </summary>
        public double M21;

        /// <summary>
        /// Area under the geodesic (meters<sup>2</sup>).
        /// </summary>
        public double S12;

        /// <summary>
        /// Initialize all the fields to Double.NaN.
        /// </summary>
        public GeodesicData()
        {
            lat1 = lon1 = azi1 = lat2 = lon2 = azi2 =
              s12 = a12 = m12 = M12 = M21 = S12 = Double.NaN;
        }
    }
}