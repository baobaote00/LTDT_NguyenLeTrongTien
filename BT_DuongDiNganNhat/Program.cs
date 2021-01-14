/**
 * TEN: NGUYỄN LÊ TRỌNG TIỀN
 * MSSV: 19211TT4165
 * NGAY: 3/12/2020
 */
namespace DuongDiNganNhat
{
    class Program
    {
        static void Main(string[] args)
        {
            TienIch_DDNN.GhiFile_MTTS("duongdingannhat.dat");
            int[][] cbt = TienIch_DDNN.TaoMaTranTrongSoTuFile("duongdingannhat.dat");
            TienIch_DDNN.inMaTran(cbt);
            int[] kc=TienIch_DDNN.Dijkstra(cbt, 1);
        }
    }
}
