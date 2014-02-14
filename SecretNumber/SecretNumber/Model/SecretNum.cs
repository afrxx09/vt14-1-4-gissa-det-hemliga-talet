using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace SecretNumber.Model
{
    public enum Outcome
    {
        Indefinite,
        Low,
        High,
        Correct,
        NoMoreGuesses,
        PreviousGuess
    }

    public class SecretNum
    {
        public const int MaxNumberOfGuesses = 7;
        private int _number;
        private List<int> _previousGuesses = new List<int>(MaxNumberOfGuesses);

        public bool CanMakeGuess { get { return (Count < MaxNumberOfGuesses && Outcome != Outcome.Correct); } }
        public int Count { get { return PreviousGuesses.Count; } }
        public int? Number{
            get
            {
                if(CanMakeGuess){ return null;}
                else{ return _number; }
            }
        }
        public Outcome Outcome { get; private set; }
        public ReadOnlyCollection<int> PreviousGuesses { get { return _previousGuesses.AsReadOnly(); } }

        public void Initialize()
        {
            Random r = new Random();
            this._number = r.Next(1, 101);
            _previousGuesses.Clear();
            Outcome = Outcome.Indefinite;
        }

        public Outcome MakeGuess(int guess)
        {
            if (guess < 1 || guess > 100)
            {
                throw new ArgumentOutOfRangeException("Värdet måste vara mellan 1 och 100");
            }
            if(PreviousGuesses.Contains(guess)) {
                Outcome = Outcome.PreviousGuess;
                return Outcome;
            }
            if (CanMakeGuess)
            {
                _previousGuesses.Add(guess);
                if (guess == _number)
                {
                    Outcome = Outcome.Correct;
                }
                else
                {
                    if (guess < _number) { Outcome = Outcome.Low; }
                    else { Outcome = Outcome.High; }
                    if (Count == MaxNumberOfGuesses) { Outcome = Outcome.NoMoreGuesses; }
                }
            }
            return Outcome;
        }

        public SecretNum()
        {
            this.Initialize();
        }

    }
}