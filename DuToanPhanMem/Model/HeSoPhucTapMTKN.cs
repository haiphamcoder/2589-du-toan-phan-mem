using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace DuToanPhanMem.Model
{
    public class HeSoPhucTapMTKN:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private GiaTriPhanMem _gt;

        private float _ef;
        private float _efw;
        private float _es;
        private int _p;

        private ObservableCollection<HeSoMT> _ds = new ObservableCollection<HeSoMT>();

        private static readonly float TOLERANCE = 0.05f;

        public float EF
        {
            get { return _ef; }
            set {
                if (Math.Abs(this._ef - value) > TOLERANCE)
                {
                    this._ef = value;
                    OnPropertyChanged(nameof(EF));
                    _gt.EF = value;
                }
            }
        }

        public float EFW
        {
            get { return _efw; }
            set {
                if (Math.Abs(this._efw - value) > TOLERANCE)
                {
                    this._efw = value;
                    OnPropertyChanged(nameof(EFW));

                }
            }
        }

        public float ES
        {
            get { return _es; }
            set {
                if (Math.Abs(this._es - value) > TOLERANCE)
                {
                    this._es = value;
                    OnPropertyChanged(nameof(ES));

                }
            }
        }

        public int P
        {
            get { return _p; }
            set {
                if (this._p != value)
                {
                    this._p = value;
                    OnPropertyChanged(nameof(P));
                    _gt.P = value;
                }
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
            DS.Add(new HeSoMT(0,0,0,0));
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
            EFW = DS.Sum(a => a.KetQua)*0.1f;
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
        private int _xepHang;
        private float _ketQua;
        private float _kinhNghiem;

        private static readonly float TOLERANCE = 0.05f;

        public int ChiSo
        {
            get { return _chiSo; }
            set { _chiSo = value; }
        }

        public int XepHang
        {
            get { return _xepHang; }
            set
            {
                if (this._xepHang != value)
                {
                    this._xepHang = value;
                    OnPropertyChanged(nameof(XepHang));
                    TinhKetQua();
                    TinhKinhNghiem();
                    hs.TinhP();

                }
            }
        }

        public float KetQua
        {
            get { return _ketQua; }
            set
            {
                if (Math.Abs(this._ketQua - value) > TOLERANCE)
                {
                    this._ketQua = value;
                    OnPropertyChanged(nameof(KetQua));
                    
                }
            }
        }

        public float KinhNghiem
        {
            get { return _kinhNghiem; }
            set
            {
                if (Math.Abs(this._kinhNghiem - value) > TOLERANCE)
                {
                    this._kinhNghiem = value;
                    OnPropertyChanged(nameof(KinhNghiem));
                    
                }
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
                    KetQua =  XepHang;
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
            if (KetQua >30)
                KinhNghiem = 1;
            else if (KetQua > 20)
                KinhNghiem = 0.6f;
            else if (KetQua > 10)
                KinhNghiem = 0.1f;
            else if (KetQua > 0)
                KinhNghiem = 0.05f;
            else
                KinhNghiem = 0;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
