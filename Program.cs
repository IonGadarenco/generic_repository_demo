namespace Generic_repository_pattern_demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IRepository<User> userRepository = new ListRepository<User>();
            IRepository<Post> postRepository = new ListRepository<Post>();
            IRepository<Comment> commentRepository = new ListRepository<Comment>();

            userRepository.Add(new User { Id = 0, Email = "ion@gmail.com", Name = "Ion" });
            userRepository.Add(new User { Id = 1, Email = "dana@gmail.com", Name = "Dana" });
            userRepository.Add(new User { Id = 2, Email = "iacov@gmail.com", Name = "Iacov" });

            postRepository.Add(new Post { Id = 0, Title = "First Post", Content = "This is the first post", UserId = 1 });
            postRepository.Add(new Post { Id = 1, Title = "Second Post", Content = "This is the Second post", UserId = 2 });

            commentRepository.Add(new Comment { Id = 0, Text = "This is the best post", PostId = 0, UserId = 1 });

            PostService postService = new PostService(postRepository, commentRepository, userRepository);

            postService.EditPostTitle(userId: 1, postId: 0, newTitle: "Edited post");

            foreach (var user in userRepository.GetAll())
            {
                Console.WriteLine(user.Name);
            }

            foreach (var post in postRepository.GetAll())
            {
                Console.WriteLine(post.Title);
            }

            foreach (var comment in commentRepository.GetAll())
            {
                Console.WriteLine(comment.Text);
            }

        }
    }
}
