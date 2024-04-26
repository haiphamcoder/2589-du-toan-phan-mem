using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DuToanPhanMem.Model
{
    public class GiaTriPhanMem:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ChiPhiPhanMem _cp;

        private long _taw;
        private long _tbf;
        private long _uucp;
        private float _tcf;
        private float _ef;
        private float _aucp;
        private long _p;
        private float _e;
        private long _h;
        private long _g;
        private readonly float TOLERANCE=0.005f;

        public long TAW
        {
            get { return _taw; }
            set {
                if (this._taw != value)
                {
                    this._taw = value;
                    OnPropertyChanged("TAW");
                    TinhG();
                }
            }
        }

        public long TBF
        {
            get { return _tbf; }
            set {
                if (this._tbf != value)
                {
                    this._tbf = value;
                    OnPropertyChanged("TBF");
                    TinhG();
                }
            }
        }

        public long UUCP
        {
            get { return _uucp; }
            set {
                if (this._uucp != value)
                {
                    this._uucp = value;
                    OnPropertyChanged("UUCP");
                    
                }
            }
        }

        public float TCF
        {
            get { return _tcf; }
            set {
                if (Math.Abs(this._tcf - value) > TOLERANCE)
                {
                    this._tcf = value;
                    OnPropertyChanged("TCF");
                    TinhG();
                }
            }
        }

        public float EF
        {
            get { return _ef; }
            set {
                if (Math.Abs(this._ef - value) > TOLERANCE)
                {
                    this._ef = value;
                    OnPropertyChanged("EF");
                    TinhG();
                }
            }
        }

        public float AUCP
        {
            get { return _aucp; }
            set {
                if (Math.Abs(this._aucp - value) > TOLERANCE)
                {
                    this._aucp = value;
                    OnPropertyChanged("AUCP");
                }
            }
        }

        public long P
        {
            get { return _p; }
            set {
                if (this._p != value)
                {
                    this._p = value;
                    OnPropertyChanged("P");
                    TinhG();
                }
            }
        }

        public float E
        {
            get { return _e; }
            set {
                if (Math.Abs(this._e - value) > TOLERANCE)
                {
                    this._e = value;
                    OnPropertyChanged("E");
                    
                }
            }
        }

        public long H
        {
            get { return _h; }
            set {
                if (this._h != value)
                {
                    this._h = value;
                    OnPropertyChanged("H");
                    TinhG();
                }
            }
        }

        public long G
        {
            get { return _g; }
            set {
                if (this._g != value)
                {
                    this._g = value;
                    OnPropertyChanged("G");
                    _cp.GiaTriPhanMem = value;
                }
            }
        }

        public GiaTriPhanMem(ChiPhiPhanMem cp)
        {
            _cp = cp;
        }

        public void TinhUUCP()
        {
            UUCP = TAW + TBF;
        }

        

        public void TinhAUCP()
        {
            AUCP = UUCP * TCF * EF;
        }

        

        public void TinhE()
        {
            
            E = 10f / 6 * AUCP;
        }

        

        public void TinhG()
        {
            TinhUUCP();
            TinhAUCP();
            TinhE();
            G = Convert.ToInt64(1.4f * E * P * H);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
