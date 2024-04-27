using JetBrains.Annotations;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace DuToanPhanMem.Model
{
    public class LuongBinhQuan : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private GiaTriPhanMem _gt;

        private ObservableCollection<Luong> _ds = new ObservableCollection<Luong>();

        public ObservableCollection<Luong> DS
        {
            get { return _ds; }
            set
            {
                this._ds = value;
            }
        }

        private long _tongChiLuong;
        public long TongChiLuong
        {
            get { return _tongChiLuong; }
            set
            {
                this._tongChiLuong = value;
                OnPropertyChanged(nameof(TongChiLuong));
            }
        }

        private long _luongBinhQuanNguoiThang;
        public long LuongBinhQuanNguoiThang
        {
            get { return _luongBinhQuanNguoiThang; }
            set
            {
                this._luongBinhQuanNguoiThang = value;
                OnPropertyChanged(nameof(LuongBinhQuanNguoiThang));
            }
        }

        private long _luongBinhQuanNguoiGio;
        public long LuongBinhQuanNguoiGio
        {
            get { return _luongBinhQuanNguoiGio; }
            set
            {
                this._luongBinhQuanNguoiGio = value;
                OnPropertyChanged(nameof(LuongBinhQuanNguoiGio));
                _gt.H = value;
            }
        }

        public LuongBinhQuan(GiaTriPhanMem gt)
        {
            this._gt = gt;
            Luong.luongBQ = this;
            DS.Add(new Luong(0, 0, 0, 0));
            DS.Add(new Luong(1, 0, 0, 0));
            DS.Add(new Luong(2, 0, 0, 0));

        }

        public void TinhTongChiLuong()
        {
            TongChiLuong = DS.Sum(x => x.Tong);
        }

        public void TinhLuongBinhQuanNguoiThang()
        {
            TinhTongChiLuong();
            long tongCB = DS.Sum(x => x.SoLuongCB);
            LuongBinhQuanNguoiThang = tongCB > 0 ? TongChiLuong / tongCB : 0;
        }

        public void TinhLuongBinhQuanNguoiGio()
        {
            TinhLuongBinhQuanNguoiThang();
            LuongBinhQuanNguoiGio = LuongBinhQuanNguoiThang / 20 / 8;
        }


        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public partial class Luong : INotifyPropertyChanged
    {
        public static LuongBinhQuan luongBQ;
        private int _stt;
        private long _mucLuong;
        private long _soLuongCB;
        private long _tong;

        public int STT
        {
            get { return _stt; }
            set
            {
                _stt = value;
            }
        }

        public long MucLuong
        {
            get { return _mucLuong; }
            set
            {
                _mucLuong = value;
                OnPropertyChanged(nameof(MucLuong));
                TinhTong();
                luongBQ.TinhLuongBinhQuanNguoiGio();
            }
        }

        public long SoLuongCB
        {
            get { return _soLuongCB; }
            set
            {
                _soLuongCB = value;
                OnPropertyChanged(nameof(SoLuongCB));
                TinhTong();
                luongBQ.TinhLuongBinhQuanNguoiGio();
            }
        }

        public long Tong
        {
            get { return _tong; }
            set
            {
                _tong = value;
                OnPropertyChanged(nameof(Tong));
            }
        }

        public Luong(int stt, long mucLuong, long soLuongCB, long tong)
        {
            STT = stt;
            MucLuong = mucLuong;
            SoLuongCB = soLuongCB;
            Tong = tong;
        }

        public void TinhTong()
        {
            Tong = MucLuong * SoLuongCB;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}
