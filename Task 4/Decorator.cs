﻿using System;
namespace Decorator.Examples
{
    class MainApp
    {
        static void Main()
        {
            var tree = new ChristmasTree();
            var greenBall = new ToyDecorator("green ball");
            var star = new ToyDecorator("star");
            var garland = new GarlandDecorator();

            greenBall.SetComponent(tree);
            star.SetComponent(greenBall);
            garland.SetComponent(star);

            garland.Inspect();
        }
    }
    
    interface IComponent
    {
        public void Inspect();
    }

    abstract class BaseDecorator : IComponent {
        protected IComponent wrapee;

        public void SetComponent(IComponent component) {
            wrapee = component;
        }

        public virtual void Inspect() {
            wrapee.Inspect();
        }
    }

    class ChristmasTree : IComponent {
        void IComponent.Inspect() {
            Console.WriteLine("Tiny lovely christmas tree");
        }
    }

    class ToyDecorator : BaseDecorator {
        private string toy;

        public ToyDecorator(string toy) {
            this.toy = toy;
        }
        public override void Inspect()
        {
            base.Inspect();
            Console.WriteLine($"There is {toy} on it");
        }
    }

    class GarlandDecorator : BaseDecorator {
        public override void Inspect()
        {
            base.Inspect();
            Console.WriteLine("There is a garland on it");
            Shine();
        }

        private void Shine() {
            Console.WriteLine("The garlang is shining");
        }
    }
}