using Notebook2.Service;
using Notebook2.ViewModel;

namespace Test
{
    
    public class TestReposirory
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestCreateSHA256()
        {
            // Arrange
            Repository repository = new Repository();

            // Act
            string password = "123456LoK\"<6*O&x$pY";
            string result = Repository.CreateSHA256(password);

            // Assert
            string expectation = "53498d2ef5addca78546e04a6467249e98938cfdb96f4bc150aa9f2947f1376d";
            Assert.AreEqual(expectation, result);
        }
        [Test]
        public void TestCheckLoginFirstPath()
        {
            // Arrange
            Repository repository = new Repository();

            // Act
            string login = "AIE_7201";
            int result = repository.CheckLogin(login);
            if(result>=1)
            {
                result = 1;
            }
            // Assert
            int expectation = 1;
            Assert.AreEqual(expectation, result);
        }
        [Test]
        public void TestCheckLoginSecondPath()
        {
            // Arrange
            Repository repository = new Repository();

            // Act
            string login = "AIE_7201";
            int result = repository.CheckLogin(login);

            // Assert
            int expectation = -1;
            Assert.AreEqual(expectation, result);
        }
        [Test]
        public void TestRegisterDataCheckLogin()
        {
            // Arrange
            Repository repository = new Repository();

            // Act
            string login = "AIE_7201";
            RegisterViewModel viewModel = new RegisterViewModel();
            viewModel.Login = login;
            var task = repository.RegisterData(viewModel);
            task.Wait(); // ожидаем завершения задачи
            var result = task.Result; // получаем результат выполнения задачи
            // Assert
            var expectation = 101;
            Assert.AreEqual(expectation, result.resultCode);
        }
        [Test]
        public void TestRegisterDataRegisterUser()
        {
            // Arrange
            Repository repository = new Repository();

            // Act
            string login = "TESTING2";
            RegisterViewModel viewModel = new RegisterViewModel();
            viewModel.Login = login;
            viewModel.Surname = "Test";
            viewModel.Name  = "Test";
            viewModel.Password = "123456";
            var task = repository.RegisterData(viewModel);
            task.Wait(); // ожидаем завершения задачи
            var result = task.Result; // получаем результат выполнения задачи
            // Assert
            var expectation = 201;
            Assert.AreEqual(expectation, result.resultCode);
        }
        [Test]
        public void TestLoginDataCheckLogin1()
        {
            // Arrange
            Repository repository = new Repository();
            // Act
            string login = "AIE_7201";
            LoginViewModel viewModel = new LoginViewModel();
            viewModel.Login = login;
            var task = repository.LoginData(viewModel);
            task.Wait(); // ожидаем завершения задачи
            var result = task.Result; // получаем результат выполнения задачи
            // Assert
            var expectation = 101;
            Assert.AreEqual(expectation, result.resultCode);
        }
        [Test]
        public void TestLoginDataCheckLogin2()
        {
            // Arrange
            Repository repository = new Repository();
            // Act
            string login = "TEEEEEESTING";
            LoginViewModel viewModel = new LoginViewModel();
            viewModel.Login = login;
            var task = repository.LoginData(viewModel);
            task.Wait(); // ожидаем завершения задачи
            var result = task.Result; // получаем результат выполнения задачи
            // Assert
            var expectation = 100;
            Assert.AreEqual(expectation, result.resultCode);
        }
        [Test]
        public void TestLoginLoginUser()
        {
            // Arrange
            Repository repository = new Repository();
            // Act
            string login = "AIE_7201";
            LoginViewModel viewModel = new LoginViewModel();
            viewModel.Login = login;
            viewModel.Password = "123456";
            var task = repository.LoginData(viewModel);
            task.Wait(); // ожидаем завершения задачи
            var result = task.Result; // получаем результат выполнения задачи
            // Assert
            var expectation = 800;
            Assert.AreEqual(expectation, result.resultCode);
        }
    }
}