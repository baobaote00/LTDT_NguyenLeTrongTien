/**
 * Ten:Nguyen Le Trong Tien
 * MSSV: 19211TT4165
 */
namespace CayBaoTrum
{
    class Canh
    {
        private int dau;
        private int cuoi;
        private int trongSo;

        public int Dau
        {
            get { return dau; }
            set { dau = value; }
        }

        public int Cuoi
        {
            get { return cuoi; }
            set { cuoi = value; }
        }

        public int TrongSo
        {
            get { return trongSo; }
            set { trongSo = value; }
        }

        public Canh(int dau, int cuoi, int trongSo)
        {
            this.dau = dau;
            this.cuoi = cuoi;
            this.trongSo = trongSo;
        }

        public Canh() { }

        public override string ToString()
        {
            return dau + "-" + cuoi + "-" + trongSo;
        }
    }
}
