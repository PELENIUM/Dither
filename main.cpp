#include <SFML/Graphics.hpp>
#include <cmath>
#include <string>
#include <cstdlib>
#include <fstream>
#include <iostream>
#include <assert.h>
#include <windows.h>

using namespace sf;

bool FileExists(const std::string& filename)
{
    WIN32_FIND_DATAA fd = { 0 };
    HANDLE hFound = FindFirstFileA(filename.c_str(), &fd);
    bool retval = hFound != INVALID_HANDLE_VALUE;
    FindClose(hFound);

    return retval;
}

int main() {
    setlocale(LC_ALL, "Russian");    
    std::string path;
    std::cout << 
 "made by\n\n\n"
 " _____     _              \n"
 "|  __ \\   | |            \n"
 "| |__) |__| |_   _  __ _ \n"
 "|  ___/ _ \\ | | | |/ _` |\n"
 "| |  |  __/ | |_| | (_| |\n"
 "|_|   \\___|_|\\__, |\\__,_|\n"
"              __/ |      \n"
"             |___/       \n\n\n"
"";
    std::cout << "Введите путь к фотографии: ";
    std::cin >> path;
    
    if (!path.empty() && FileExists(path)) {
        srand(time(NULL));
        Image img;
        img.loadFromFile(path);
        const int width = img.getSize().x;
        const int height = img.getSize().y;
        RenderWindow window(VideoMode(width, height), "changer");
        bool isChanged = false;
        while (window.isOpen()) {
            Event event;
            while (window.pollEvent(event)) {
                if (event.type == Event::Closed)
                    window.close();
                if (Keyboard::isKeyPressed(Keyboard::Escape))
                    window.close();
            }
            window.clear({ 255, 255, 255 });
            
            if (!isChanged) {
                for (int i = 0; i < width / 2; i++) {
                    for (int j = 0; j < height / 2; j++) {
                        RectangleShape* drawingRect = new RectangleShape(Vector2f(2, 2));
                        Color pixelColor = img.getPixel(i * 2, j * 2);
                        short int r = pixelColor.r;
                        short int g = pixelColor.g;
                        short int b = pixelColor.b;

                        float c = 0.2989 * r + 0.5870 * g + 0.1140 * b;

                        c += rand() % 20 - 10;

                        if (c >= 255)
                            c = 255;
                        if (c <= 5)
                            c = 0;

                        if (c < 51.2) {
                            drawingRect->setFillColor(Color{ (Uint8)(12), (Uint8)(33), (Uint8)(88) });
                            goto next;
                        }
                        if (c < 102.4) {
                            drawingRect->setFillColor(Color{ (Uint8)(39), (Uint8)(77), (Uint8)(116) });
                            goto next;
                        }
                        if (c < 153.6) {
                            drawingRect->setFillColor(Color{ (Uint8)(112), (Uint8)(137), (Uint8)(144) });
                            goto next;
                        }
                        if (c < 204.8) {
                            drawingRect->setFillColor(Color{ (Uint8)(197), (Uint8)(105), (Uint8)(64) });
                            goto next;
                        }
                        else {
                            drawingRect->setFillColor(Color{ (Uint8)(213), (Uint8)(208), (Uint8)(202) });
                            goto next;
                        }
                    next: drawingRect->setPosition(Vector2f(i * 2, j * 2));
                        window.draw(*drawingRect);
                        delete drawingRect;
                    }
                }

                Texture texture;
                texture.create(window.getSize().x, window.getSize().y);

                texture.update(window);
                
                path.insert(path.rfind('.'), "_edited");

                texture.copyToImage().saveToFile(path);
                window.close();
            }
            window.display();
        }
        return 0;
    }
    else {
        std::cout << "Некорректный путь";
    }
}