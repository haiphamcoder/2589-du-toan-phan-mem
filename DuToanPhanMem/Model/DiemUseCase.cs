using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DuToanPhanMem.Model
{
    public class DiemUseCase:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private GiaTriPhanMem _gt;

        private int _soBDonGian;
        private int _soBTrungBinh;
        private int _soBPhucTap;
        private int _tongSoB;
        private float _diemBDonGian;
        private float _diemBTrungBinh;
        private float _diemBPhucTap;
        private float _tongDiemB;

        private int _soMDonGian;
        private int _soMTrungBinh;
        private int _soMPhucTap;
        private int _tongSoM;
        private float _diemMDonGian;
        private float _diemMTrungBinh;
        private float _diemMPhucTap;
        private float _tongDiemM;

        private int _soTDonGian;
        private int _soTTrungBinh;
        private int _soTPhucTap;
        private int _tongSoT;
        private float _diemTDonGian;
        private float _diemTTrungBinh;
        private float _diemTPhucTap;
        private float _tongDiemT;

        private float _tbf;

        public int SoBDonGian
        {
            get { return _soBDonGian; }
            set
            {
                if (this._soBDonGian != value)
                {
                    this._soBDonGian = value;
                    OnPropertyChanged("SoBDonGian");
                    TinhTBF();
                }
            }
        }

        public int SoBTrungBinh
        {
            get { return _soBTrungBinh; }
            set
            {
                if (this._soBTrungBinh != value)
                {
                    this._soBTrungBinh = value;
                    OnPropertyChanged("SoBTrungBinh");
                    TinhTBF();
                }
            }
        }

        public int SoBPhucTap
        {
            get { return _soBPhucTap; }
            set
            {
                if (this._soBPhucTap != value)
                {
                    this._soBPhucTap = value;
                    OnPropertyChanged("SoBPhucTap");
                    TinhTBF();
                }
            }
        }

        public int TongSoB
        {
            get { return _tongSoB; }
            set
            {
                if (this._tongSoB != value)
                {
                    this._tongSoB = value;
                    OnPropertyChanged("TongSoB");
                }
            }
        }

        public float DiemBDonGian
        {
            get { return _diemBDonGian; }
            set
            {
                if (this._diemBDonGian != value)
                {
                    this._diemBDonGian = value;
                    OnPropertyChanged("DiemBDonGian");
                }
            }
        }

        public float DiemBTrungBinh
        {
            get { return _diemBTrungBinh; }
            set
            {
                if (this._diemBTrungBinh != value)
                {
                    this._diemBTrungBinh = value;
                    OnPropertyChanged("DiemBTrungBinh");
                }
            }
        }

        public float DiemBPhucTap
        {
            get { return _diemBPhucTap; }
            set
            {
                if (this._diemBPhucTap != value)
                {
                    this._diemBPhucTap = value;
                    OnPropertyChanged("DiemBPhucTap");
                }
            }
        }

        public float TongDiemB
        {
            get { return _tongDiemB; }
            set
            {
                if (this._tongDiemB != value)
                {
                    this._tongDiemB = value;
                    OnPropertyChanged("TongDiemB");
                }
            }
        }

        public int SoMDonGian
        {
            get { return _soMDonGian; }
            set
            {
                if (this._soMDonGian != value)
                {
                    this._soMDonGian = value;
                    OnPropertyChanged("SoMDonGian");
                    TinhTBF();
                }
            }
        }

        public int SoMTrungBinh
        {
            get { return _soMTrungBinh; }
            set
            {
                if (this._soMTrungBinh != value)
                {
                    this._soMTrungBinh = value;
                    OnPropertyChanged("SoMTrungBinh");
                    TinhTBF();
                }
            }
        }

        public int SoMPhucTap
        {
            get { return _soMPhucTap; }
            set
            {
                if (this._soMPhucTap != value)
                {
                    this._soMPhucTap = value;
                    OnPropertyChanged("SoMPhucTap");
                    TinhTBF();
                }
            }
        }

        public int TongSoM
        {
            get { return _tongSoM; }
            set
            {
                if (this._tongSoM != value)
                {
                    this._tongSoM = value;
                    OnPropertyChanged("TongSoM");
                }
            }
        }

        public float DiemMDonGian
        {
            get { return _diemMDonGian; }
            set
            {
                if (this._diemMDonGian != value)
                {
                    this._diemMDonGian = value;
                    OnPropertyChanged("DiemMDonGian");
                }
            }
        }

        public float DiemMTrungBinh
        {
            get { return _diemMTrungBinh; }
            set
            {
                if (this._diemMTrungBinh != value)
                {
                    this._diemMTrungBinh = value;
                    OnPropertyChanged("DiemMTrungBinh");
                }
            }
        }

        public float DiemMPhucTap
        {
            get { return _diemMPhucTap; }
            set
            {
                if (this._diemMPhucTap != value)
                {
                    this._diemMPhucTap = value;
                    OnPropertyChanged("DiemMPhucTap");
                }
            }
        }

        public float TongDiemM
        {
            get { return _tongDiemM; }
            set
            {
                if (this._tongDiemM != value)
                {
                    this._tongDiemM = value;
                    OnPropertyChanged("TongDiemM");
                }
            }
        }

        public int SoTDonGian
        {
            get { return _soTDonGian; }
            set
            {
                if (this._soTDonGian != value)
                {
                    this._soTDonGian = value;
                    OnPropertyChanged("SoTDonGian");
                    TinhTBF();
                }
            }
        }

        public int SoTTrungBinh
        {
            get { return _soTTrungBinh; }
            set
            {
                if (this._soTTrungBinh != value)
                {
                    this._soTTrungBinh = value;
                    OnPropertyChanged("SoTTrungBinh");
                    TinhTBF();
                }
            }
        }

        public int SoTPhucTap
        {
            get { return _soTPhucTap; }
            set
            {
                if (this._soTPhucTap != value)
                {
                    this._soTPhucTap = value;
                    OnPropertyChanged("SoTPhucTap");
                    TinhTBF();
                }
            }
        }

        public int TongSoT
        {
            get { return _tongSoT; }
            set
            {
                if (this._tongSoT != value)
                {
                    this._tongSoT = value;
                    OnPropertyChanged("TongSoT");
                }
            }
        }

        public float DiemTDonGian
        {
            get { return _diemTDonGian; }
            set
            {
                if (this._diemTDonGian != value)
                {
                    this._diemTDonGian = value;
                    OnPropertyChanged("DiemTDonGian");
                }
            }
        }

        public float DiemTTrungBinh
        {
            get { return _diemTTrungBinh; }
            set
            {
                if (this._diemTTrungBinh != value)
                {
                    this._diemTTrungBinh = value;
                    OnPropertyChanged("DiemTTrungBinh");
                }
            }
        }

        public float DiemTPhucTap
        {
            get { return _diemTPhucTap; }
            set
            {
                if (this._diemTPhucTap != value)
                {
                    this._diemTPhucTap = value;
                    OnPropertyChanged("DiemTPhucTap");
                }
            }
        }

        public float TongDiemT
        {
            get { return _tongDiemT; }
            set
            {
                if (this._tongDiemT != value)
                {
                    this._tongDiemT = value;
                    OnPropertyChanged("TongDiemT");
                }
            }
        }

        

        public float TBF
        {
            get { return _tbf; }
            set
            {
                if (this._tbf != value)
                {
                    this._tbf = value;
                    OnPropertyChanged("TBF");
                    _gt.TBF = (long) value;
                }
            }
        }

        public DiemUseCase(GiaTriPhanMem gt)
        {
            _gt = gt;
        }

        public void TinhDiemBDonGian()
        {
            DiemBDonGian = 5 * SoBDonGian;
        }

        public void TinhDiemBTrungBinh()
        {
            DiemBTrungBinh = 10 * SoBTrungBinh;
        }

        public void TinhDiemBPhucTap()
        {
            DiemBPhucTap = 15 * SoBPhucTap;
        }

        public void TinhDiemMDonGian()
        {
            DiemMDonGian = 1.2f * 5 * SoMDonGian;
        }

        public void TinhDiemMTrungBinh()
        {
            DiemMTrungBinh = 1.2f * 10 * SoMTrungBinh;
        }

        public void TinhDiemMPhucTap()
        {
            DiemMPhucTap = 1.2f * 15 * SoMPhucTap;
        }

        public void TinhDiemTDonGian()
        {
            DiemTDonGian = 1.5f * 5 * SoTDonGian;
        }

        public void TinhDiemTTrungBinh()
        {
            DiemTTrungBinh = 1.5f * 10 * SoTTrungBinh;
        }

        public void TinhDiemTPhucTap()
        {
            DiemTPhucTap = 1.5f * 15 * SoTPhucTap;
        }

        public void TinhTongSoB()
        {
            TongSoB = SoBDonGian + SoBTrungBinh + SoBPhucTap;
        }

        public void TinhTongDiemB()
        {
            TongDiemB = DiemBDonGian + DiemBTrungBinh + DiemBPhucTap;
        }

        public void TinhTongSoM()
        {
            TongSoM = SoMDonGian + SoMTrungBinh + SoMPhucTap;
        }

        public void TinhTongDiemM()
        {
            TongDiemM = DiemMDonGian + DiemMTrungBinh + DiemMPhucTap;
        }

        public void TinhTongSoT()
        {
            TongSoT = SoTDonGian + SoTTrungBinh + SoTPhucTap;
        }

        public void TinhTongDiemT()
        {
            TongDiemT = DiemTDonGian + DiemTTrungBinh + DiemTPhucTap;
        }

        public void TinhTBF()
        {
            TinhDiemBDonGian();
            TinhDiemBTrungBinh();
            TinhDiemBPhucTap();
            TinhDiemMDonGian();
            TinhDiemMTrungBinh();
            TinhDiemMPhucTap();
            TinhDiemTDonGian();
            TinhDiemTTrungBinh();
            TinhDiemTPhucTap();
            TinhTongSoB();
            TinhTongSoM();
            TinhTongSoT();
            TinhTongDiemB();
            TinhTongDiemM();
            TinhTongDiemT();
            TBF = TongDiemB + TongDiemM + TongDiemT;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
