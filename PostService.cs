using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_repository_pattern_demo
{
    internal class PostService
    {
        private readonly IRepository<Post> _postRepository;
        private readonly IRepository<Comment> _commentRepository;
        private readonly IRepository<User> _userRepository;

        public PostService(IRepository<Post> postRepository, IRepository<Comment> commentRepository, IRepository<User> userRepository)
        { 
            _postRepository = postRepository;
            _commentRepository = commentRepository;
            _userRepository = userRepository;
        }

        public bool EditPostTitle(int userId, int postId, string newTitle)
        {
            User user = _userRepository.GetById(userId);
            if (user == null)
            {
                Console.WriteLine($"User with Id = {userId} not found");
                return false;
            }

            Post post = _postRepository.GetById(postId);
            if (post == null)
            {
                Console.WriteLine($"Post with Id = {postId} not found");
                return false;
            }

            if (post.UserId != user.Id)
            {
                Console.WriteLine("You don't have access to edit this post!");
                return false;
            }

            post.Title = newTitle;
            _postRepository.Update(post);
            return true;
        }

    }
}
