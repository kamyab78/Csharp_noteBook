using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace final_project_ap
{
    class Clock
    {
        Canvas ClockCanvas;
        Label DayLabel;
        Line SecondCounter;
        Line MinuteCounter;
        Line MinutePointer;
        Line HourCounter;
        Line HourPointer;

        double CenterX;
        double CenterY;

        double[] CircleRadius;

        public Clock(Canvas clockCanvas, Label dayLabel, Line secondCounter, Line minuteCounter, Line minutePointer, Line hourCounter, Line hourPointer)
        {
            this.ClockCanvas = clockCanvas;
            this.DayLabel = dayLabel;
            this.SecondCounter = secondCounter;
            this.MinuteCounter = minuteCounter;
            this.MinutePointer = minutePointer;
            this.HourCounter = hourCounter;
            this.HourPointer = hourPointer;

            this.CenterX = ClockCanvas.Width / 2;
            this.CenterY = ClockCanvas.Height / 2;

            CircleRadius = new double[8];

            CircleRadius[0] = 10;
            CircleRadius[1] = 35;
            CircleRadius[2] = 40;
            CircleRadius[3] = 45;
            CircleRadius[4] = 50;
            CircleRadius[5] = 55;
            CircleRadius[6] = 60;
            CircleRadius[7] = 65;
        }

        public void Run()
        {
            Aroundlines();
            DrawingSecondHandCounter();
            DrawingMinuteHandCounter();
            DrawingHourHandCounter();
            SetDayLabel();
        }

        private void Aroundlines()
        {
            for (int i = 0; i < 60; i++)
            {
                double angle = i * (2 * Math.PI / 60);
                double cos = Math.Cos(angle);
                double sin = Math.Sin(angle);

                Line line = new Line();
                line.Stroke = Brushes.Black;
                line.StrokeThickness = 1;

                if (i % 5 == 0)
                    line.StrokeThickness = 1.5;
                if (i % 15 == 0)
                    line.StrokeThickness = 3;

                if (i % 5 == 0)
                {
                    line.X1 = CircleRadius[5] * cos + CenterX;
                    line.Y1 = CircleRadius[5] * sin + CenterY;

                    line.X2 = CircleRadius[7] * cos + CenterX;
                    line.Y2 = CircleRadius[7] * sin + CenterY;
                }

                else
                {
                    line.X1 = CircleRadius[6] * cos + CenterX;
                    line.Y1 = CircleRadius[6] * sin + CenterY;

                    line.X2 = CircleRadius[7] * cos + CenterX;
                    line.Y2 = CircleRadius[7] * sin + CenterY;
                }

                ClockCanvas.Children.Add(line);
            }
        }

        private void DrawingSecondHandCounter()
        {
            Thread secondWorker = new Thread(() =>
            {
                int second = DateTime.Now.Second;

                double angle = second * (2 * Math.PI / 60) - (Math.PI / 2);

                while (true)
                {
                    angle += Math.PI / 3000;
                    if (angle < 2 * Math.PI)
                        angle -= 2 * Math.PI;

                    double cos = Math.Cos(angle);
                    double sin = Math.Sin(angle);

                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        SecondCounter.X1 = -1 * CircleRadius[0] * cos + CenterX;
                        SecondCounter.Y1 = -1 * CircleRadius[0] * sin + CenterY;

                        SecondCounter.X2 = CircleRadius[6] * cos + CenterX;
                        SecondCounter.Y2 = CircleRadius[6] * sin + CenterY;
                    }));
                    Thread.Sleep(10);
                }
            });
            secondWorker.SetApartmentState(ApartmentState.STA);
            secondWorker.Start();
        }

        private void DrawingMinuteHandCounter()
        {
            Thread minuteWorker = new Thread(() =>
            {
                int second = DateTime.Now.Second;
                int minute = DateTime.Now.Minute;

                double angle = minute * (2 * Math.PI / 60) + (second * Math.PI / 1800) - (Math.PI / 2);

                while (true)
                {
                    angle += Math.PI / 1800;
                    if (angle < 2 * Math.PI)
                        angle -= 2 * Math.PI;

                    double cos = Math.Cos(angle);
                    double sin = Math.Sin(angle);

                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        MinuteCounter.X1 = -1 * CircleRadius[0] * cos + CenterX;
                        MinuteCounter.Y1 = -1 * CircleRadius[0] * sin + CenterY;

                        MinuteCounter.X2 = CircleRadius[4] * cos + CenterX;
                        MinuteCounter.Y2 = CircleRadius[4] * sin + CenterY;


                        MinutePointer.X1 = CircleRadius[3] * cos + CenterX;
                        MinutePointer.Y1 = CircleRadius[3] * sin + CenterY;

                        MinutePointer.X2 = CircleRadius[4] * cos + CenterX;
                        MinutePointer.Y2 = CircleRadius[4] * sin + CenterY;
                    }));
                    Thread.Sleep(1000);
                }
            });
            minuteWorker.SetApartmentState(ApartmentState.STA);
            minuteWorker.Start();
        }

        private void DrawingHourHandCounter()
        {
            Thread hourWorker = new Thread(() =>
            {
                int minute = DateTime.Now.Minute;
                int hour = DateTime.Now.Hour;
                if (12 <= hour)
                    hour -= 12;

                double angle = hour * (2 * Math.PI / 12) + (minute * Math.PI / 360) - (Math.PI / 2);

                while (true)
                {
                    angle += Math.PI / 360;
                    if (angle < 2 * Math.PI)
                        angle -= 2 * Math.PI;

                    double cos = Math.Cos(angle);
                    double sin = Math.Sin(angle);

                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        HourCounter.X1 = -1 * CircleRadius[0] * cos + CenterX;
                        HourCounter.Y1 = -1 * CircleRadius[0] * sin + CenterY;

                        HourCounter.X2 = CircleRadius[2] * cos + CenterX;
                        HourCounter.Y2 = CircleRadius[2] * sin + CenterY;


                        HourPointer.X1 = CircleRadius[1] * cos + CenterX;
                        HourPointer.Y1 = CircleRadius[1] * sin + CenterY;

                        HourPointer.X2 = CircleRadius[2] * cos + CenterX;
                        HourPointer.Y2 = CircleRadius[2] * sin + CenterY;
                    }));
                    Thread.Sleep(60_000);
                }
            });
            hourWorker.SetApartmentState(ApartmentState.STA);
            hourWorker.Start();
        }

        private void SetDayLabel()
        {
            Thread SetDayLabelWorker = new Thread(() =>
            {
                int hourPassedToMiliSecond = DateTime.Now.Hour * 60 * 60 * 1_000;
                int minutePassedToMilisecond = DateTime.Now.Minute * 60 * 1_000;
                int secondPassToMilisecond = DateTime.Now.Second * 1_000;
                int MiliSecondPassed = secondPassToMilisecond + minutePassedToMilisecond + hourPassedToMiliSecond;
                while (true)
                {
                    int day = DateTime.Now.Day;
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        DayLabel.Content = day.ToString();
                    }));
                    Thread.Sleep(1_000 * 60 * 60 * 24 - MiliSecondPassed);
                }
            });
            SetDayLabelWorker.SetApartmentState(ApartmentState.STA);
            SetDayLabelWorker.Start();
        }
    }
}
