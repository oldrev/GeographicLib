using System;
using Xunit;
using GeographicLib;

namespace GeographicLib.Tests
{
    public class GeodesicTest
    {
        private static bool IsNaN(double x) => double.IsNaN(x);

        private static readonly PolygonArea s_polygon = new PolygonArea(Geodesic.WGS84, false);

        private static readonly PolygonArea s_polyline = new PolygonArea(Geodesic.WGS84, true);

        private static void AssertEquals(double expected, double value, double delta) =>
           Assert.InRange(value, expected - delta, expected + delta);


        private static PolygonResult Planimeter(double[][] points)
        {
            s_polygon.Clear();
            for (int i = 0; i < points.Length; ++i)
            {
                s_polygon.AddPoint(points[i][0], points[i][1]);
            }
            return s_polygon.Compute(false, true);
        }

        private static PolygonResult PolyLength(double[][] points)
        {
            s_polyline.Clear();
            for (int i = 0; i < points.Length; ++i)
            {
                s_polyline.AddPoint(points[i][0], points[i][1]);
            }
            return s_polyline.Compute(false, true);
        }

        private static readonly double[][] testcases = new double[][] {
            new double[]{ 35.60777, -139.44815, 111.098748429560326,
             -11.17491, -69.95921, 129.289270889708762,
             8935244.5604818305, 80.50729714281974, 6273170.2055303837,
             0.16606318447386067, 0.16479116945612937, 12841384694976.432},
            new double[] {55.52454, 106.05087, 22.020059880982801,
             77.03196, 197.18234, 109.112041110671519,
             4105086.1713924406, 36.892740690445894, 3828869.3344387607,
             0.80076349608092607, 0.80101006984201008, 61674961290615.615},
            new double[] {-21.97856, 142.59065, -32.44456876433189,
             41.84138, 98.56635, -41.84359951440466,
             8394328.894657671, 75.62930491011522, 6161154.5773110616,
             0.24816339233950381, 0.24930251203627892, -6637997720646.717},
            new double[] {-66.99028, 112.2363, 173.73491240878403,
             -12.70631, 285.90344, 2.512956620913668,
             11150344.2312080241, 100.278634181155759, 6289939.5670446687,
             -0.17199490274700385, -0.17722569526345708, -121287239862139.744},
            new double[] {-17.42761, 173.34268, -159.033557661192928,
             -15.84784, 5.93557, -20.787484651536988,
             16076603.1631180673, 144.640108810286253, 3732902.1583877189,
             -0.81273638700070476, -0.81299800519154474, 97825992354058.708},
            new double[] {32.84994, 48.28919, 150.492927788121982,
             -56.28556, 202.29132, 48.113449399816759,
             16727068.9438164461, 150.565799985466607, 3147838.1910180939,
             -0.87334918086923126, -0.86505036767110637, -72445258525585.010},
            new double [] {6.96833, 52.74123, 92.581585386317712,
             -7.39675, 206.17291, 90.721692165923907,
             17102477.2496958388, 154.147366239113561, 2772035.6169917581,
             -0.89991282520302447, -0.89986892177110739, -1311796973197.995},
            new double [] {-50.56724, -16.30485, -105.439679907590164,
             -33.56571, -94.97412, -47.348547835650331,
             6455670.5118668696, 58.083719495371259, 5409150.7979815838,
             0.53053508035997263, 0.52988722644436602, 41071447902810.047},
            new double[] {-58.93002, -8.90775, 140.965397902500679,
             -8.91104, 133.13503, 19.255429433416599,
             11756066.0219864627, 105.755691241406877, 6151101.2270708536,
             -0.26548622269867183, -0.27068483874510741, -86143460552774.735},
            new double[] {-68.82867, -74.28391, 93.774347763114881,
             -50.63005, -8.36685, 34.65564085411343,
             3956936.926063544, 35.572254987389284, 3708890.9544062657,
             0.81443963736383502, 0.81420859815358342, -41845309450093.787},
            new double[] {-10.62672, -32.0898, -86.426713286747751,
             5.883, -134.31681, -80.473780971034875,
             11470869.3864563009, 103.387395634504061, 6184411.6622659713,
             -0.23138683500430237, -0.23155097622286792, 4198803992123.548},
            new double[] {-21.76221, 166.90563, 29.319421206936428,
             48.72884, 213.97627, 43.508671946410168,
             9098627.3986554915, 81.963476716121964, 6299240.9166992283,
             0.13965943368590333, 0.14152969707656796, 10024709850277.476},
            new double[] {-19.79938, -174.47484, 71.167275780171533,
             -11.99349, -154.35109, 65.589099775199228,
             2319004.8601169389, 20.896611684802389, 2267960.8703918325,
             0.93427001867125849, 0.93424887135032789, -3935477535005.785},
            new double[] {-11.95887, -116.94513, 92.712619830452549,
             4.57352, 7.16501, 78.64960934409585,
             13834722.5801401374, 124.688684161089762, 5228093.177931598,
             -0.56879356755666463, -0.56918731952397221, -9919582785894.853},
            new double[] {-87.85331, 85.66836, -65.120313040242748,
             66.48646, 16.09921, -4.888658719272296,
             17286615.3147144645, 155.58592449699137, 2635887.4729110181,
             -0.90697975771398578, -0.91095608883042767, 42667211366919.534},
            new double[] {1.74708, 128.32011, -101.584843631173858,
             -11.16617, 11.87109, -86.325793296437476,
             12942901.1241347408, 116.650512484301857, 5682744.8413270572,
             -0.44857868222697644, -0.44824490340007729, 10763055294345.653},
            new double[] {-25.72959, -144.90758, -153.647468693117198,
             -57.70581, -269.17879, -48.343983158876487,
             9413446.7452453107, 84.664533838404295, 6356176.6898881281,
             0.09492245755254703, 0.09737058264766572, 74515122850712.444},
            new double[] {-41.22777, 122.32875, 14.285113402275739,
             -7.57291, 130.37946, 10.805303085187369,
             3812686.035106021, 34.34330804743883, 3588703.8812128856,
             0.82605222593217889, 0.82572158200920196, -2456961531057.857},
            new double[] {11.01307, 138.25278, 79.43682622782374,
             6.62726, 247.05981, 103.708090215522657,
             11911190.819018408, 107.341669954114577, 6070904.722786735,
             -0.29767608923657404, -0.29785143390252321, 17121631423099.696},
            new double[] {-29.47124, 95.14681, -163.779130441688382,
             -27.46601, -69.15955, -15.909335945554969,
             13487015.8381145492, 121.294026715742277, 5481428.9945736388,
             -0.51527225545373252, -0.51556587964721788, 104679964020340.318}};

        [Fact]
        public void InverseCheck()
        {
            for (int i = 0; i < testcases.Length; ++i)
            {
                double
                  lat1 = testcases[i][0], lon1 = testcases[i][1], azi1 = testcases[i][2],
                  lat2 = testcases[i][3], lon2 = testcases[i][4], azi2 = testcases[i][5],
                  s12 = testcases[i][6], a12 = testcases[i][7], m12 = testcases[i][8],
                  M12 = testcases[i][9], M21 = testcases[i][10], S12 = testcases[i][11];
                GeodesicData inv = Geodesic.WGS84.Inverse(lat1, lon1, lat2, lon2,
                                                          GeodesicMask.ALL |
                                                          GeodesicMask.LONG_UNROLL);
                AssertEquals(lon2, inv.lon2, 1e-13);
                AssertEquals(azi1, inv.azi1, 1e-13);
                AssertEquals(azi2, inv.azi2, 1e-13);
                AssertEquals(s12, inv.s12, 1e-8);
                AssertEquals(a12, inv.a12, 1e-13);
                AssertEquals(m12, inv.m12, 1e-8);
                AssertEquals(M12, inv.M12, 1e-15);
                AssertEquals(M21, inv.M21, 1e-15);
                AssertEquals(S12, inv.S12, 0.1);
            }
        }

        [Fact]
        public void DirectCheck()
        {
            for (int i = 0; i < testcases.Length; ++i)
            {
                double
                  lat1 = testcases[i][0], lon1 = testcases[i][1], azi1 = testcases[i][2],
                  lat2 = testcases[i][3], lon2 = testcases[i][4], azi2 = testcases[i][5],
                  s12 = testcases[i][6], a12 = testcases[i][7], m12 = testcases[i][8],
                  M12 = testcases[i][9], M21 = testcases[i][10], S12 = testcases[i][11];
                GeodesicData dir = Geodesic.WGS84.Direct(lat1, lon1, azi1, s12,
                                                         GeodesicMask.ALL |
                                                         GeodesicMask.LONG_UNROLL);
                AssertEquals(lat2, dir.lat2, 1e-13);
                AssertEquals(lon2, dir.lon2, 1e-13);
                AssertEquals(azi2, dir.azi2, 1e-13);
                AssertEquals(a12, dir.a12, 1e-13);
                AssertEquals(m12, dir.m12, 1e-8);
                AssertEquals(M12, dir.M12, 1e-15);
                AssertEquals(M21, dir.M21, 1e-15);
                AssertEquals(S12, dir.S12, 0.1);
            }
        }

        [Fact]
        public void ArcDirectCheck()
        {
            for (int i = 0; i < testcases.Length; ++i)
            {
                double
                  lat1 = testcases[i][0], lon1 = testcases[i][1], azi1 = testcases[i][2],
                  lat2 = testcases[i][3], lon2 = testcases[i][4], azi2 = testcases[i][5],
                  s12 = testcases[i][6], a12 = testcases[i][7], m12 = testcases[i][8],
                  M12 = testcases[i][9], M21 = testcases[i][10], S12 = testcases[i][11];
                GeodesicData dir = Geodesic.WGS84.ArcDirect(lat1, lon1, azi1, a12,
                                                         GeodesicMask.ALL |
                                                         GeodesicMask.LONG_UNROLL);
                AssertEquals(lat2, dir.lat2, 1e-13);
                AssertEquals(lon2, dir.lon2, 1e-13);
                AssertEquals(azi2, dir.azi2, 1e-13);
                AssertEquals(s12, dir.s12, 1e-8);
                AssertEquals(m12, dir.m12, 1e-8);
                AssertEquals(M12, dir.M12, 1e-15);
                AssertEquals(M21, dir.M21, 1e-15);
                AssertEquals(S12, dir.S12, 0.1);
            }
        }

        [Fact]
        public void GeodSolve0()
        {
            GeodesicData inv = Geodesic.WGS84.Inverse(40.6, -73.8,
                                                      49.01666667, 2.55);
            AssertEquals(inv.azi1, 53.47022, 0.5e-5);
            AssertEquals(inv.azi2, 111.59367, 0.5e-5);
            AssertEquals(inv.s12, 5853226, 0.5);
        }

        [Fact]
        public void GeodSolve1()
        {
            GeodesicData dir = Geodesic.WGS84.Direct(40.63972222, -73.77888889,
                                                     53.5, 5850e3);
            AssertEquals(dir.lat2, 49.01467, 0.5e-5);
            AssertEquals(dir.lon2, 2.56106, 0.5e-5);
            AssertEquals(dir.azi2, 111.62947, 0.5e-5);
        }

        [Fact]
        public void GeodSolve2()
        {
            // Check fix for antipodal prolate bug found 2010-09-04
            Geodesic geod = new Geodesic(6.4e6, -1 / 150.0);
            GeodesicData inv = geod.Inverse(0.07476, 0, -0.07476, 180);
            AssertEquals(inv.azi1, 90.00078, 0.5e-5);
            AssertEquals(inv.azi2, 90.00078, 0.5e-5);
            AssertEquals(inv.s12, 20106193, 0.5);
            inv = geod.Inverse(0.1, 0, -0.1, 180);
            AssertEquals(inv.azi1, 90.00105, 0.5e-5);
            AssertEquals(inv.azi2, 90.00105, 0.5e-5);
            AssertEquals(inv.s12, 20106193, 0.5);
        }

        [Fact]
        public void GeodSolve4()
        {
            // Check fix for short line bug found 2010-05-21
            GeodesicData inv = Geodesic.WGS84.Inverse(36.493349428792, 0,
                                                      36.49334942879201, .0000008);
            AssertEquals(inv.s12, 0.072, 0.5e-3);
        }

        [Fact]
        public void GeodSolve5()
        {
            // Check fix for point2=pole bug found 2010-05-03
            GeodesicData dir = Geodesic.WGS84.Direct(0.01777745589997, 30, 0, 10e6);
            AssertEquals(dir.lat2, 90, 0.5e-5);
            if (dir.lon2 < 0)
            {
                AssertEquals(dir.lon2, -150, 0.5e-5);
                AssertEquals(Math.Abs(dir.azi2), 180, 0.5e-5);
            }
            else
            {
                AssertEquals(dir.lon2, 30, 0.5e-5);
                AssertEquals(dir.azi2, 0, 0.5e-5);
            }
        }

        [Fact]
        public void GeodSolve6()
        {
            // Check fix for volatile sbet12a bug found 2011-06-25 (gcc 4.4.4
            // x86 -O3).  Found again on 2012-03-27 with tdm-mingw32 (g++ 4.6.1).
            GeodesicData inv =
              Geodesic.WGS84.Inverse(88.202499451857, 0,
                                     -88.202499451857, 179.981022032992859592);
            AssertEquals(inv.s12, 20003898.214, 0.5e-3);
            inv = Geodesic.WGS84.Inverse(89.262080389218, 0,
                                         -89.262080389218, 179.992207982775375662);
            AssertEquals(inv.s12, 20003925.854, 0.5e-3);
            inv = Geodesic.WGS84.Inverse(89.333123580033, 0, -89.333123580032997687,
                                         179.99295812360148422);
            AssertEquals(inv.s12, 20003926.881, 0.5e-3);
        }

        [Fact]
        public void GeodSolve9()
        {
            // Check fix for volatile x bug found 2011-06-25 (gcc 4.4.4 x86 -O3)
            GeodesicData inv =
              Geodesic.WGS84.Inverse(56.320923501171, 0,
                                     -56.320923501171, 179.664747671772880215);
            AssertEquals(inv.s12, 19993558.287, 0.5e-3);
        }

        [Fact]
        public void GeodSolve10()
        {
            // Check fix for adjust tol1_ bug found 2011-06-25 (Visual Studio
            // 10 rel + debug)
            GeodesicData inv =
              Geodesic.WGS84.Inverse(52.784459512564, 0,
                                     -52.784459512563990912, 179.634407464943777557);
            AssertEquals(inv.s12, 19991596.095, 0.5e-3);
        }

        [Fact]
        public void GeodSolve11()
        {
            // Check fix for bet2 = -bet1 bug found 2011-06-25 (Visual Studio
            // 10 rel + debug)
            GeodesicData inv =
              Geodesic.WGS84.Inverse(48.522876735459, 0,
                                     -48.52287673545898293, 179.599720456223079643);
            AssertEquals(inv.s12, 19989144.774, 0.5e-3);
        }

        [Fact]
        public void GeodSolve12()
        {
            // Check fix for inverse geodesics on extreme prolate/oblate
            // ellipsoids Reported 2012-08-29 Stefan Guenther
            // <stefan.gunther@embl.de>; fixed 2012-10-07
            Geodesic geod = new Geodesic(89.8, -1.83);
            GeodesicData inv = geod.Inverse(0, 0, -10, 160);
            AssertEquals(inv.azi1, 120.27, 1e-2);
            AssertEquals(inv.azi2, 105.15, 1e-2);
            AssertEquals(inv.s12, 266.7, 1e-1);
        }

        [Fact]
        public void GeodSolve14()
        {
            // Check fix for inverse ignoring lon12 = nan
            GeodesicData inv = Geodesic.WGS84.Inverse(0, 0, 1, Double.NaN);
            Assert.True(IsNaN(inv.azi1));
            Assert.True(IsNaN(inv.azi2));
            Assert.True(IsNaN(inv.s12));
        }

        [Fact]
        public void GeodSolve15()
        {
            // Initial implementation of Math::eatanhe was wrong for e^2 < 0.  This
            // checks that this is fixed.
            Geodesic geod = new Geodesic(6.4e6, -1 / 150.0);
            GeodesicData dir = geod.Direct(1, 2, 3, 4, GeodesicMask.AREA);
            AssertEquals(dir.S12, 23700, 0.5);
        }

        [Fact]
        public void GeodSolve17()
        {
            // Check fix for LONG_UNROLL bug found on 2015-05-07
            GeodesicData dir =
              Geodesic.WGS84.Direct(40, -75, -10, 2e7,
                                    GeodesicMask.STANDARD | GeodesicMask.LONG_UNROLL);
            AssertEquals(dir.lat2, -39, 1);
            AssertEquals(dir.lon2, -254, 1);
            AssertEquals(dir.azi2, -170, 1);
            GeodesicLine line = Geodesic.WGS84.Line(40, -75, -10);
            dir = line.Position(2e7, GeodesicMask.STANDARD | GeodesicMask.LONG_UNROLL);
            AssertEquals(dir.lat2, -39, 1);
            AssertEquals(dir.lon2, -254, 1);
            AssertEquals(dir.azi2, -170, 1);
            dir = Geodesic.WGS84.Direct(40, -75, -10, 2e7);
            AssertEquals(dir.lat2, -39, 1);
            AssertEquals(dir.lon2, 105, 1);
            AssertEquals(dir.azi2, -170, 1);
            dir = line.Position(2e7);
            AssertEquals(dir.lat2, -39, 1);
            AssertEquals(dir.lon2, 105, 1);
            AssertEquals(dir.azi2, -170, 1);
        }

        [Fact]
        public void GeodSolve26()
        {
            // Check 0/0 problem with area calculation on sphere 2015-09-08
            Geodesic geod = new Geodesic(6.4e6, 0);
            GeodesicData inv = geod.Inverse(1, 2, 3, 4, GeodesicMask.AREA);
            AssertEquals(inv.S12, 49911046115.0, 0.5);
        }

        [Fact]
        public void GeodSolve28()
        {
            // Check for bad placement of assignment of r.a12 with |f| > 0.01 (bug in
            // Java implementation fixed on 2015-05-19).
            Geodesic geod = new Geodesic(6.4e6, 0.1);
            GeodesicData dir = geod.Direct(1, 2, 10, 5e6);
            AssertEquals(dir.a12, 48.55570690, 0.5e-8);
        }

        [Fact]
        public void GeodSolve29()
        {
            // Check longitude unrolling with inverse calculation 2015-09-16
            GeodesicData dir = Geodesic.WGS84.Inverse(0, 539, 0, 181);
            AssertEquals(dir.lon1, 179, 1e-10);
            AssertEquals(dir.lon2, -179, 1e-10);
            AssertEquals(dir.s12, 222639, 0.5);
            dir = Geodesic.WGS84.Inverse(0, 539, 0, 181,
                                         GeodesicMask.STANDARD |
                                         GeodesicMask.LONG_UNROLL);
            AssertEquals(dir.lon1, 539, 1e-10);
            AssertEquals(dir.lon2, 541, 1e-10);
            AssertEquals(dir.s12, 222639, 0.5);
        }

        [Fact]
        public void GeodSolve33()
        {
            // Check max(-0.0,+0.0) issues 2015-08-22 (triggered by bugs in Octave --
            // sind(-0.0) = +0.0 -- and in some version of Visual Studio --
            // fmod(-0.0, 360.0) = +0.0.
            GeodesicData inv = Geodesic.WGS84.Inverse(0, 0, 0, 179);
            AssertEquals(inv.azi1, 90.00000, 0.5e-5);
            AssertEquals(inv.azi2, 90.00000, 0.5e-5);
            AssertEquals(inv.s12, 19926189, 0.5);
            inv = Geodesic.WGS84.Inverse(0, 0, 0, 179.5);
            AssertEquals(inv.azi1, 55.96650, 0.5e-5);
            AssertEquals(inv.azi2, 124.03350, 0.5e-5);
            AssertEquals(inv.s12, 19980862, 0.5);
            inv = Geodesic.WGS84.Inverse(0, 0, 0, 180);
            AssertEquals(inv.azi1, 0.00000, 0.5e-5);
            AssertEquals(Math.Abs(inv.azi2), 180.00000, 0.5e-5);
            AssertEquals(inv.s12, 20003931, 0.5);
            inv = Geodesic.WGS84.Inverse(0, 0, 1, 180);
            AssertEquals(inv.azi1, 0.00000, 0.5e-5);
            AssertEquals(Math.Abs(inv.azi2), 180.00000, 0.5e-5);
            AssertEquals(inv.s12, 19893357, 0.5);
            Geodesic geod = new Geodesic(6.4e6, 0);
            inv = geod.Inverse(0, 0, 0, 179);
            AssertEquals(inv.azi1, 90.00000, 0.5e-5);
            AssertEquals(inv.azi2, 90.00000, 0.5e-5);
            AssertEquals(inv.s12, 19994492, 0.5);
            inv = geod.Inverse(0, 0, 0, 180);
            AssertEquals(inv.azi1, 0.00000, 0.5e-5);
            AssertEquals(Math.Abs(inv.azi2), 180.00000, 0.5e-5);
            AssertEquals(inv.s12, 20106193, 0.5);
            inv = geod.Inverse(0, 0, 1, 180);
            AssertEquals(inv.azi1, 0.00000, 0.5e-5);
            AssertEquals(Math.Abs(inv.azi2), 180.00000, 0.5e-5);
            AssertEquals(inv.s12, 19994492, 0.5);
            geod = new Geodesic(6.4e6, -1 / 300.0);
            inv = geod.Inverse(0, 0, 0, 179);
            AssertEquals(inv.azi1, 90.00000, 0.5e-5);
            AssertEquals(inv.azi2, 90.00000, 0.5e-5);
            AssertEquals(inv.s12, 19994492, 0.5);
            inv = geod.Inverse(0, 0, 0, 180);
            AssertEquals(inv.azi1, 90.00000, 0.5e-5);
            AssertEquals(inv.azi2, 90.00000, 0.5e-5);
            AssertEquals(inv.s12, 20106193, 0.5);
            inv = geod.Inverse(0, 0, 0.5, 180);
            AssertEquals(inv.azi1, 33.02493, 0.5e-5);
            AssertEquals(inv.azi2, 146.97364, 0.5e-5);
            AssertEquals(inv.s12, 20082617, 0.5);
            inv = geod.Inverse(0, 0, 1, 180);
            AssertEquals(inv.azi1, 0.00000, 0.5e-5);
            AssertEquals(Math.Abs(inv.azi2), 180.00000, 0.5e-5);
            AssertEquals(inv.s12, 20027270, 0.5);
        }

        [Fact]
        public void GeodSolve55()
        {
            // Check fix for nan + point on equator or pole not returning all nans in
            // Geodesic::Inverse, found 2015-09-23.
            GeodesicData inv = Geodesic.WGS84.Inverse(Double.NaN, 0, 0, 90);
            Assert.True(IsNaN(inv.azi1));
            Assert.True(IsNaN(inv.azi2));
            Assert.True(IsNaN(inv.s12));
            inv = Geodesic.WGS84.Inverse(Double.NaN, 0, 90, 3);
            Assert.True(IsNaN(inv.azi1));
            Assert.True(IsNaN(inv.azi2));
            Assert.True(IsNaN(inv.s12));
        }

        [Fact]
        public void GeodSolve59()
        {
            // Check for points close with longitudes close to 180 deg apart.
            GeodesicData inv = Geodesic.WGS84.Inverse(5, 0.00000000000001, 10, 180);
            AssertEquals(inv.azi1, 0.000000000000035, 1.5e-14);
            AssertEquals(inv.azi2, 179.99999999999996, 1.5e-14);
            AssertEquals(inv.s12, 18345191.174332713, 4e-9);
        }

        [Fact]
        public void GeodSolve61()
        {
            // Make sure small negative azimuths are west-going
            GeodesicData dir =
              Geodesic.WGS84.Direct(45, 0, -0.000000000000000003, 1e7,
                                    GeodesicMask.STANDARD | GeodesicMask.LONG_UNROLL);
            AssertEquals(dir.lat2, 45.30632, 0.5e-5);
            AssertEquals(dir.lon2, -180, 0.5e-5);
            AssertEquals(Math.Abs(dir.azi2), 180, 0.5e-5);
            GeodesicLine line = Geodesic.WGS84.InverseLine(45, 0, 80,
                                                           -0.000000000000000003);
            dir = line.Position(1e7, GeodesicMask.STANDARD | GeodesicMask.LONG_UNROLL);
            AssertEquals(dir.lat2, 45.30632, 0.5e-5);
            AssertEquals(dir.lon2, -180, 0.5e-5);
            AssertEquals(Math.Abs(dir.azi2), 180, 0.5e-5);
        }

        [Fact]
        public void GeodSolve65()
        {
            // Check for bug in east-going check in GeodesicLine (needed to check for
            // sign of 0) and sign error in area calculation due to a bogus override
            // of the code for alp12.  Found/fixed on 2015-12-19.
            GeodesicLine line = Geodesic.WGS84.InverseLine(30, -0.000000000000000001,
                                                           -31, 180);
            GeodesicData dir =
              line.Position(1e7, GeodesicMask.ALL | GeodesicMask.LONG_UNROLL);
            AssertEquals(dir.lat1, 30.00000, 0.5e-5);
            AssertEquals(dir.lon1, -0.00000, 0.5e-5);
            AssertEquals(Math.Abs(dir.azi1), 180.00000, 0.5e-5);
            AssertEquals(dir.lat2, -60.23169, 0.5e-5);
            AssertEquals(dir.lon2, -0.00000, 0.5e-5);
            AssertEquals(Math.Abs(dir.azi2), 180.00000, 0.5e-5);
            AssertEquals(dir.s12, 10000000, 0.5);
            AssertEquals(dir.a12, 90.06544, 0.5e-5);
            AssertEquals(dir.m12, 6363636, 0.5);
            AssertEquals(dir.M12, -0.0012834, 0.5e7);
            AssertEquals(dir.M21, 0.0013749, 0.5e-7);
            AssertEquals(dir.S12, 0, 0.5);
            dir = line.Position(2e7, GeodesicMask.ALL | GeodesicMask.LONG_UNROLL);
            AssertEquals(dir.lat1, 30.00000, 0.5e-5);
            AssertEquals(dir.lon1, -0.00000, 0.5e-5);
            AssertEquals(Math.Abs(dir.azi1), 180.00000, 0.5e-5);
            AssertEquals(dir.lat2, -30.03547, 0.5e-5);
            AssertEquals(dir.lon2, -180.00000, 0.5e-5);
            AssertEquals(dir.azi2, -0.00000, 0.5e-5);
            AssertEquals(dir.s12, 20000000, 0.5);
            AssertEquals(dir.a12, 179.96459, 0.5e-5);
            AssertEquals(dir.m12, 54342, 0.5);
            AssertEquals(dir.M12, -1.0045592, 0.5e7);
            AssertEquals(dir.M21, -0.9954339, 0.5e-7);
            AssertEquals(dir.S12, 127516405431022.0, 0.5);
        }

        [Fact]
        public void GeodSolve69()
        {
            // Check for InverseLine if line is slightly west of S and that s13 is
            // correctly set.
            GeodesicLine line =
              Geodesic.WGS84.InverseLine(-5, -0.000000000000002, -10, 180);
            GeodesicData dir =
              line.Position(2e7, GeodesicMask.STANDARD | GeodesicMask.LONG_UNROLL);
            AssertEquals(dir.lat2, 4.96445, 0.5e-5);
            AssertEquals(dir.lon2, -180.00000, 0.5e-5);
            AssertEquals(dir.azi2, -0.00000, 0.5e-5);
            dir = line.Position(0.5 * line.Distance(),
                                GeodesicMask.STANDARD | GeodesicMask.LONG_UNROLL);
            AssertEquals(dir.lat2, -87.52461, 0.5e-5);
            AssertEquals(dir.lon2, -0.00000, 0.5e-5);
            AssertEquals(dir.azi2, -180.00000, 0.5e-5);
        }

        [Fact]
        public void GeodSolve71()
        {
            // Check that DirectLine sets s13.
            GeodesicLine line = Geodesic.WGS84.DirectLine(1, 2, 45, 1e7);
            GeodesicData dir =
              line.Position(0.5 * line.Distance(),
                            GeodesicMask.STANDARD | GeodesicMask.LONG_UNROLL);
            AssertEquals(dir.lat2, 30.92625, 0.5e-5);
            AssertEquals(dir.lon2, 37.54640, 0.5e-5);
            AssertEquals(dir.azi2, 55.43104, 0.5e-5);
        }

        [Fact]
        public void GeodSolve73()
        {
            // Check for backwards from the pole bug reported by Anon on 2016-02-13.
            // This only affected the Java implementation.  It was introduced in Java
            // version 1.44 and fixed in 1.46-SNAPSHOT on 2016-01-17.
            GeodesicData dir = Geodesic.WGS84.Direct(90, 10, 180, -1e6);
            AssertEquals(dir.lat2, 81.04623, 0.5e-5);
            AssertEquals(dir.lon2, -170, 0.5e-5);
            AssertEquals(dir.azi2, 0, 0.5e-5);
        }

        [Fact]
        public void GeodSolve74()
        {
            // Check fix for inaccurate areas, bug introduced in v1.46, fixed
            // 2015-10-16.
            GeodesicData inv = Geodesic.WGS84.Inverse(54.1589, 15.3872,
                                                      54.1591, 15.3877,
                                                      GeodesicMask.ALL);
            AssertEquals(inv.azi1, 55.723110355, 5e-9);
            AssertEquals(inv.azi2, 55.723515675, 5e-9);
            AssertEquals(inv.s12, 39.527686385, 5e-9);
            AssertEquals(inv.a12, 0.000355495, 5e-9);
            AssertEquals(inv.m12, 39.527686385, 5e-9);
            AssertEquals(inv.M12, 0.999999995, 5e-9);
            AssertEquals(inv.M21, 0.999999995, 5e-9);
            AssertEquals(inv.S12, 286698586.30197, 5e-4);
        }

        [Fact]
        public void GeodSolve76()
        {
            // The distance from Wellington and Salamanca (a classic failure of
            // Vincenty)
            GeodesicData inv = Geodesic.WGS84.Inverse(-(41 + 19 / 60.0), 174 + 49 / 60.0,
                                                      40 + 58 / 60.0, -(5 + 30 / 60.0));
            AssertEquals(inv.azi1, 160.39137649664, 0.5e-11);
            AssertEquals(inv.azi2, 19.50042925176, 0.5e-11);
            AssertEquals(inv.s12, 19960543.857179, 0.5e-6);
        }

        [Fact]
        public void GeodSolve78()
        {
            // An example where the NGS calculator fails to converge */
            GeodesicData inv = Geodesic.WGS84.Inverse(27.2, 0.0, -27.1, 179.5);
            AssertEquals(inv.azi1, 45.82468716758, 0.5e-11);
            AssertEquals(inv.azi2, 134.22776532670, 0.5e-11);
            AssertEquals(inv.s12, 19974354.765767, 0.5e-6);
        }

        [Fact]
        public void Planimeter0()
        {
            // Check fix for pole-encircling bug found 2011-03-16
            var pa = new double[][] { new double[] { 89, 0 }, new double[] { 89, 90 }, new double[] { 89, 180 }, new double[] { 89, 270 } };
            PolygonResult a = Planimeter(pa);
            AssertEquals(a.Perimeter, 631819.8745, 1e-4);
            AssertEquals(a.Area, 24952305678.0, 1);

            var pb = new double[][] { new double[] { -89, 0 }, new double[] { -89, 90 }, new double[] { -89, 180 }, new double[] { -89, 270 } };
            a = Planimeter(pb);
            AssertEquals(a.Perimeter, 631819.8745, 1e-4);
            AssertEquals(a.Area, -24952305678.0, 1);

            var pc = new double[][] { new double[] { 0, -1 }, new double[] { -1, 0 }, new double[] { 0, 1 }, new double[] { 1, 0 } };
            a = Planimeter(pc);
            AssertEquals(a.Perimeter, 627598.2731, 1e-4);
            AssertEquals(a.Area, 24619419146.0, 1);

            var pd = new double[][] { new double[] { 90, 0 }, new double[] { 0, 0 }, new double[] { 0, 90 } };
            a = Planimeter(pd);
            AssertEquals(a.Perimeter, 30022685, 1);
            AssertEquals(a.Area, 63758202715511.0, 1);
            a = PolyLength(pd);
            AssertEquals(a.Perimeter, 20020719, 1);
            Assert.True(IsNaN(a.Area));
        }

        [Fact]
        public void Planimeter5()
        {
            // Check fix for Planimeter pole crossing bug found 2011-06-24
            var points = new double[][] { new double[] { 89, 0.1 }, new double[] { 89, 90.1 }, new double[] { 89, -179.9 } };
            PolygonResult a = Planimeter(points);
            AssertEquals(539297, a.Perimeter, 1);
            AssertEquals(12476152838.5, a.Area, 1);
        }

        [Fact]
        public void Planimeter6()
        {
            // Check fix for Planimeter lon12 rounding bug found 2012-12-03
            var pa = new double[][] { new double[] { 9, -0.00000000000001 }, new double[] { 9, 180 }, new double[] { 9, 0 } };
            PolygonResult a = Planimeter(pa);
            AssertEquals(a.Perimeter, 36026861, 1);
            AssertEquals(a.Area, 0, 1);
            var pb = new double[][] { new double[] { 9, 0.00000000000001 }, new double[] { 9, 0 }, new double[] { 9, 180 } };
            a = Planimeter(pb);
            AssertEquals(a.Perimeter, 36026861, 1);
            AssertEquals(a.Area, 0, 1);
            var pc = new double[][] { new double[] { 9, 0.00000000000001 }, new double[] { 9, 180 }, new double[] { 9, 0 } };
            a = Planimeter(pc);
            AssertEquals(a.Perimeter, 36026861, 1);
            AssertEquals(a.Area, 0, 1);
            var pd = new double[][] { new double[] { 9, -0.00000000000001 }, new double[] { 9, 0 }, new double[] { 9, 180 } };
            a = Planimeter(pd);
            AssertEquals(a.Perimeter, 36026861, 1);
            AssertEquals(a.Area, 0, 1);
        }

        [Fact]
        public void Planimeter12()
        {
            // Area of arctic circle (not really -- adjunct to rhumb-area test)
            double[][] points = new double[][] { new double[] { 66.562222222, 0 }, new double[] { 66.562222222, 180 } };
            PolygonResult a = Planimeter(points);
            Assert.Equal(10465729, a.Perimeter, 0);
            Assert.Equal(0, a.Area, 0);
        }

        [Fact]
        public void Planimeter13()
        {
            // Check encircling pole twice
            double[][] points = new double[][] {new double[]{89,-360}, new double[] {89,-240}, new double[]{89,-120},
                         new double[]{89,0},new double[] {89,120}, new double[]{89,240}};
            PolygonResult a = Planimeter(points);
            AssertEquals(1160741, a.Perimeter, 1);
            AssertEquals(32415230256.0, a.Area, 1);
        }

    }
}
