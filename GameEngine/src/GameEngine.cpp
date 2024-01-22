#include <glad/gl.h>
#include <GLFW/glfw3.h>

#include "GameEngine.h"

using namespace std;

int main() {
    GLFWwindow* window = glfwCreateWindow(500, 500, "LearnOpenGL", NULL, NULL);
    glfwMakeContextCurrent(window);

    int version = gladLoadGL(glfwGetProcAddress);
    if (version == 0) {
        printf("Failed to initialize OpenGL context\n");
        return -1;
    }

    printf("Loaded OpenGL %d.%d\n", GLAD_VERSION_MAJOR(version), GLAD_VERSION_MINOR(version));

	return 0;
}