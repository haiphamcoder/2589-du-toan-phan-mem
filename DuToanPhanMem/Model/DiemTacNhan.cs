using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DuToanPhanMem.Model
{
    public class DiemTacNhan:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private GiaTriPhanMem _gt;

        private int _soTNDonGian;
        private int _soTNTrungBinh;
        private int _soTNPhucTap;
        private int _diemTNDonGian;
        private int _diemTNTrungBinh;
        private int _diemTNPhucTap;
        private int _taw;

        public int SoTNDonGian
        {
            get { return _soTNDonGian; }
            set {
                if (this._soTNDonGian != value)
                {
                    this._soTNDonGian = value;
                    OnPropertyChanged("SoTNDonGian");
                    TinhTAW();
                }
            }
        }

        public int SoTNTrungBinh
        {
            get { return _soTNTrungBinh; }
            set {
                if (this._soTNTrungBinh != value)
                {
                    this._soTNTrungBinh = value;
                    OnPropertyChanged("SoTNTrungBinh");
                    TinhTAW();
                }
            }
        }

        public int SoTNPhucTap
        {
            get { return _soTNPhucTap; }
            set {
                if (this._soTNPhucTap != value)
                {
                    this._soTNPhucTap = value;
                    OnPropertyChanged("SoTNPhucTap");
                    TinhTAW();
                }
            }
        }

        public int DiemTNDonGian
        {
            get { return this._diemTNDonGian; }
            set {
                if (this._diemTNDonGian != value)
                {
                    this._diemTNDonGian = value;
                    OnPropertyChanged("DiemTNDonGian");
                }
            }
        }

        public int DiemTNTrungBinh
        {
            get { return _diemTNTrungBinh; }
            set {
                if (this._diemTNTrungBinh != value)
                {
                    this._diemTNTrungBinh = value;
                    OnPropertyChanged("DiemTNTrungBinh");
                }
            }
        }

        public int DiemTNPhucTap
        {
            get { return _diemTNPhucTap; }
            set {
                if (this._diemTNPhucTap != value)
                {
                    this._diemTNPhucTap = value;
                    OnPropertyChanged("DiemTNPhucTap");
                }
            }
        }

        public int TAW
        {
            get { return _taw; }
            set {
                if (this._taw != value)
                {
                    this._taw = value;
                    OnPropertyChanged("TAW");
                    _gt.TAW = value;
                }
            }
        }

        public DiemTacNhan(GiaTriPhanMem gt)
        {
            _gt = gt;
        }

        public void TinhDiemTNDonGian()
        {
            DiemTNDonGian = SoTNDonGian;
        }

        public void TinhDiemTNTrungBinh()
        {
            DiemTNTrungBinh = 2*SoTNTrungBinh;
        }

        public void TinhDiemTNPhucTap()
        {
            DiemTNPhucTap = 3*SoTNPhucTap;
        }

        public void TinhTAW()
        {
            TinhDiemTNDonGian();
            TinhDiemTNTrungBinh();
            TinhDiemTNPhucTap();
            TAW = DiemTNDonGian + DiemTNTrungBinh + DiemTNPhucTap;
        }


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
