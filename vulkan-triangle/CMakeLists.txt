cmake_minimum_required(VERSION 3.10)
project(vulkan_triangle)

set(CMAKE_CXX_STANDARD 17)

set(CMAKE_PREFIX_PATH "$ENV{HOME}/.local")

find_package(Vulkan REQUIRED)
find_package(glfw3 REQUIRED)

add_executable(vulkan_triangle main.cpp)
target_link_libraries(vulkan_triangle PRIVATE glfw Vulkan::Vulkan)
