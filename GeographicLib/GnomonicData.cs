/**
 * Implementation of the net.sf.geographiclib.GnomonicData class
 *
 * Copyright (c) BMW Car IT GmbH (2014-2016) <sebastian.mattheis@bmw-carit.de>
 * and licensed under the MIT/X11 License. For more information, see
 * https://geographiclib.sourceforge.io/
 **********************************************************************/
using System;

namespace GeographicLib
{
    /**
     * The results of gnomonic projection.
     * <p>

     * This is used to return the results for a gnomonic projection of a point
     * (<i>lat</i>, <i>lon</i>) given a center point of projection (<i>lat0</i>,
     * <i>lon0</i>). The returned GnomonicData objects always include the
     * parameters provided to
     * {@link Gnomonic#Forward Gnomonic.Forward}
     * and
     * {@link Gnomonic#Reverse Gnomonic.Reverse}
     * and it always includes the fields <i>x</i>, <i>y</i>, <i>azi</i>. and
     * <i>rk</i>.
     **********************************************************************/
    public readonly struct GnomonicData
    {
        /**
         * latitude of center point of projection (degrees).
         **********************************************************************/
        public double lat0 { get; }
        /**
         * longitude of center point of projection (degrees).
         **********************************************************************/
        public double lon0 { get; }
        /**
         * latitude of point (degrees).
         **********************************************************************/
        public double lat { get; }
        /**
         * longitude of point (degrees).
         **********************************************************************/
        public double lon { get; }
        /**
         * easting of point (meters).
         **********************************************************************/
        public double x { get; }
        /**
         * northing of point (meters).
         **********************************************************************/
        public double y { get; }
        /**
         * azimuth of geodesic at point (degrees).
         **********************************************************************/
        public double azi { get; }
        /**
         * reciprocal of azimuthal scale at point.
         **********************************************************************/
        public double rk { get; }

        /**
         * Constructor initializing all the fields for gnomonic projection of a point
         * (<i>lat</i>, <i>lon</i>) given a center point of projection (<i>lat0</i>,
         * <i>lon0</i>).
         * <p>
         * @param lat0
         *          latitude of center point of projection (degrees).
         * @param lon0
         *          longitude of center point of projection (degrees).
         * @param lat
         *          latitude of point (degrees).
         * @param lon
         *          longitude of point (degrees).
         * @param x
         *          easting of point (meters).
         * @param y
         *          northing of point (meters).
         * @param azi
         *          azimuth of geodesic at point (degrees).
         * @param rk
         *          reciprocal of azimuthal scale at point.
         */
        public GnomonicData(double lat0 = double.NaN, double lon0 = double.NaN, double lat = double.NaN, double lon = double.NaN,
            double x = double.NaN, double y = double.NaN, double azi = double.NaN, double rk = double.NaN)
        {
            this.lat0 = lat0;
            this.lon0 = lon0;
            this.lat = lat;
            this.lon = lon;
            this.x = x;
            this.y = y;
            this.azi = azi;
            this.rk = rk;
        }
    }

}