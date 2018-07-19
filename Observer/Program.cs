﻿namespace Observer
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;

    class Program
    {
        static void Main(string[] args)
        {
            Subject subject = new Subject();
            Observer observer = new Observer(subject, "Center", "\t\t");
            Observer observer2 = new Observer(subject, "Right", "\t\t\t\t");
            subject.Go();
        }
    }

    class Simulator : IEnumerable
    {
        string[] moves = { "5", "3", "1", "6", "7" };

        public IEnumerator GetEnumerator()
        {
            foreach (string element in moves)
                yield return element;
        }
    }

    interface ISubject
    {
        void AddObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers(string s);
    }

    class Subject : ISubject
    {
        public List<IObserver> Observers { get; private set; }

        private Simulator simulator;

        private const int speed = 200;

        public Subject()
        {
            Observers = new List<IObserver>();
            simulator = new Simulator();
        }

        public void AddObserver(IObserver observer)
        {
            Observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            Observers.Remove(observer);
        }

        public void NotifyObservers(string s)
        {
            foreach (var observer in Observers)
            {
                observer.Update(s);
            }
        }

        public void Go()
        {
            new Thread(new ThreadStart(Run)).Start();
        }

        void Run()
        {
            foreach (string s in simulator)
            {
                Console.WriteLine("Subject: " + s);
                NotifyObservers(s);
                Thread.Sleep(speed);
            }
        }
    }

    interface IObserver
    {
        void Update(string state);
    }

    class Observer : IObserver
    {
        string name;

        ISubject subject;

        string state;

        string gap;

        public Observer(ISubject subject, string name, string gap)
        {
            this.subject = subject;
            this.name = name;
            this.gap = gap;
            subject.AddObserver(this);
        }

        public void Update(string subjectState)
        {
            state = subjectState;
            Console.WriteLine(gap + name + ": " + state);
        }
    }
}