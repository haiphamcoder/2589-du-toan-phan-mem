using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace DuToanPhanMem.Model
{
    public class HeSoPhucTapMTKN : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private GiaTriPhanMem _gt;

        private float _ef;
        private float _efw;
        private float _es;
        private int _p;

        private ObservableCollection<HeSoMT> _ds = new ObservableCollection<HeSoMT>();

        public float EF
        {
            get { return _ef; }
            set
            {
                this._ef = value;
                OnPropertyChanged(nameof(EF));
                _gt.EF = value;
            }
        }

        public float EFW
        {
            get { return _efw; }
            set
            {
                this._efw = value;
                OnPropertyChanged(nameof(EFW));
            }
        }

        public float ES
        {
            get { return _es; }
            set
            {
                this._es = value;
                OnPropertyChanged(nameof(ES));
            }
        }

        public int P
        {
            get { return _p; }
            set
            {
                this._p = value;
                OnPropertyChanged(nameof(P));
                _gt.P = value;
            }
        }

        public ObservableCollection<HeSoMT> DS
        {
            get { return _ds; }
            set { _ds = value; }
        }

        public HeSoPhucTapMTKN(GiaTriPhanMem gt)
        {
            _gt = gt;
            HeSoMT.hs = this;
            DS.Add(new HeSoMT(0, 0, 0, 0));
            DS.Add(new HeSoMT(1, 0, 0, 0));
            DS.Add(new HeSoMT(2, 0, 0, 0));
            DS.Add(new HeSoMT(3, 0, 0, 0));
            DS.Add(new HeSoMT(4, 0, 0, 0));
            DS.Add(new HeSoMT(5, 0, 0, 0));
            DS.Add(new HeSoMT(6, 0, 0, 0));
            DS.Add(new HeSoMT(7, 0, 0, 0));
        }

        public void TinhEFW()
        {
            EFW = DS.Sum(a => a.KetQua);
        }

        public void TinhEF()
        {
            EF = 1.4f - 0.03f * EFW;

        }

        public void TinhES()
        {
            ES = DS.Sum(a => a.KinhNghiem);
        }

        public void TinhP()
        {
            TinhEFW();
            TinhEF();
            TinhES();

            if (ES >= 3)
                P = 20;
            else if (ES >= 1)
                P = 32;
            else
                P = 48;
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public partial class HeSoMT : INotifyPropertyChanged
    {
        public static HeSoPhucTapMTKN hs;
        private int _chiSo;
        private float _xepHang;
        private float _ketQua;
        private float _kinhNghiem;

        public int ChiSo
        {
            get { return _chiSo; }
            set { _chiSo = value; }
        }

        public float XepHang
        {
            get { return _xepHang; }
            set
            {
                this._xepHang = value;
                OnPropertyChanged(nameof(XepHang));
                TinhKetQua();
                TinhKinhNghiem();
                hs.TinhP();
            }
        }

        public float KetQua
        {
            get { return _ketQua; }
            set
            {
                if (this._ketQua != value)
                {
                    this._ketQua = value;
                    OnPropertyChanged(nameof(KetQua));
                    TinhKinhNghiem();
                    hs.TinhP();
                }
            }
        }

        public float KinhNghiem
        {
            get { return _kinhNghiem; }
            set
            {
                this._kinhNghiem = value;
                OnPropertyChanged(nameof(KinhNghiem));
            }
        }



        public HeSoMT(int chiso, int xephang, float ketqua, float kinhnghiem)
        {
            ChiSo = chiso;
            XepHang = xephang;
            KetQua = ketqua;
            KinhNghiem = kinhnghiem;
        }



        public void TinhKetQua()
        {
            switch (ChiSo)
            {
                case 0:
                    KetQua = 1.5f * XepHang;
                    break;
                case 1:
                    KetQua = 0.5f * XepHang;
                    break;
                case 2:
                    KetQua = XepHang;
                    break;
                case 3:
                    KetQua = 0.5f * XepHang;
                    break;
                case 4:
                    KetQua = XepHang;
                    break;
                case 5:
                    KetQua = 2 * XepHang;
                    break;
                case 6:
                    KetQua = -XepHang;
                    break;
                case 7:
                    KetQua = -XepHang;
                    break;

            }
        }

        public void TinhKinhNghiem()
        {
            if (KetQua > 3f)
                KinhNghiem = 1f;
            else if (KetQua > 2f)
                KinhNghiem = 0.6f;
            else if (KetQua > 1f)
                KinhNghiem = 0.1f;
            else if (KetQua > 0f)
                KinhNghiem = 0.05f;
            else
                KinhNghiem = 0f;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
