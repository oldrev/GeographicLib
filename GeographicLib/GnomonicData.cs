﻿/**
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
    public sealed class GnomonicData
    {
        /**
         * latitude of center point of projection (degrees).
         **********************************************************************/
        public double lat0 { get; set; }
        /**
         * longitude of center point of projection (degrees).
         **********************************************************************/
        public double lon0 { get; set; }
        /**
         * latitude of point (degrees).
         **********************************************************************/
        public double lat { get; set; }
        /**
         * longitude of point (degrees).
         **********************************************************************/
        public double lon { get; set; }
        /**
         * easting of point (meters).
         **********************************************************************/
        public double x { get; set; }
        /**
         * northing of point (meters).
         **********************************************************************/
        public double y { get; set; }
        /**
         * azimuth of geodesic at point (degrees).
         **********************************************************************/
        public double azi { get; set; }
        /**
         * reciprocal of azimuthal scale at point.
         **********************************************************************/
        public double rk { get; set; }

        /**
         * Initialize all the fields to Double.NaN.
         **********************************************************************/
        public GnomonicData()
        {
            lat0 = lon0 = lat = lon = x = y = azi = rk = Double.NaN;
        }

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
        public GnomonicData(double lat0, double lon0, double lat, double lon,
            double x, double y, double azi, double rk)
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