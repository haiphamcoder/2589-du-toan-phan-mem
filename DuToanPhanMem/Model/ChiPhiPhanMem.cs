using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DuToanPhanMem.Model
{
    public class ChiPhiPhanMem:INotifyPropertyChanged
    {
        private long _giaTriPhanMem;
        private long _chiPhiChung;
        private long _thue;
        private long _tong;
       

        public long GiaTriPhanMem
        {
            get { return this._giaTriPhanMem; }
            set
            {
                if (_giaTriPhanMem != value)
                {
                    this._giaTriPhanMem = value;
                    OnPropertyChanged("GiaTriPhanMem");
                    TinhChiPhi();
                }
                    

            }
        }

        public long ChiPhiChung {
            get { return this._chiPhiChung; }
            set
            {
                if (this._chiPhiChung != value)
                {
                    this._chiPhiChung = value;
                    OnPropertyChanged("ChiPhiChung");
                    TinhChiPhi();
                }
            }
        }

        public long Thue {
            get { return this._thue; }
            set
            {
                if (this._thue != value)
                {
                    this._thue = value;
                    OnPropertyChanged("Thue");
                    TinhChiPhi();
                }


            }
        }

        public long Tong {
            get { return this._tong; }
            set
            {
                if (this._tong != value)
                {
                    this._tong = value;
                    OnPropertyChanged("Tong");
                }


            }
        }


        

        public void TinhC()
        {
            ChiPhiChung = Convert.ToInt64( 0.65f * GiaTriPhanMem);
        }

        public void TinhTL()
        {
            
            Thue = Convert.ToInt64( 0.06f * (GiaTriPhanMem + ChiPhiChung));
        }

        public void TinhChiPhi()
        {
            TinhC();
            TinhTL();
            Tong = GiaTriPhanMem + ChiPhiChung + Thue;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
