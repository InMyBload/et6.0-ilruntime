namespace ET
{
    namespace EventType
    {
        //这里都换成 class 不知道为什么 在ilruntime  Game.EventSystem.Publish发布后 出现NotSupportedException: Specified method is not supported. 报错
        //但是看烟雨的Demo ILRT 中却可以直接使用 strtct
        public class AppStart
        {
        }

        public class ChangePosition
        {
            public Unit Unit;
        }

        public class ChangeRotation
        {
            public Unit Unit;
        }

        public class PingChange
        {
            public Scene ZoneScene;
            public long Ping;
        }

        public class AfterCreateZoneScene
        {
            public Scene ZoneScene;
        }

        public class AfterCreateLoginScene
        {
            public Scene LoginScene;
        }

        public class AppStartInitFinish
        {
            public Scene ZoneScene;
        }

        public class LoginFinish
        {
            public Scene ZoneScene;
        }

        public class LoadingBegin
        {
            public Scene Scene;
        }

        public class LoadingFinish
        {
            public Scene Scene;
        }

        public class EnterMapFinish
        {
            public Scene ZoneScene;
        }

        public class AfterUnitCreate
        {
            public Unit Unit;
        }

        public class MoveStart
        {
            public Unit Unit;
        }

        public class MoveStop
        {
            public Unit Unit;
        }
    }
}